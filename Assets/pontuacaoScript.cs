using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontuacaoScript : MonoBehaviour
{
    public int coleta;//pontuacao
    public GameObject vitoriaHud;
    public  int numeroDeFlores;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(coleta == numeroDeFlores)
        {
            vitoriaHud.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flor")
        {
            Debug.Log("Pegou");
            coleta++;
            Destroy(other.gameObject);
        }
    }
}

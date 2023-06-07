using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontuacaoScript : MonoBehaviour
{
    public int coleta;//pontuacao
    public GameObject vitoriaHud;
    public  int numeroDeFlores;//Pontuacao para ganhar jogo 
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
            FlorAnimacao flor = other.gameObject.GetComponent<FlorAnimacao>();
            
            if(flor.boa == true)
            {
                Debug.Log("Pegou boa");
                coleta++;
                Destroy(other.gameObject);
            }
            else if(flor.boa == false)
            {
                Debug.Log("Pegou ruim");
                coleta--;
                Destroy(other.gameObject);
            }
            
        }
    }
}

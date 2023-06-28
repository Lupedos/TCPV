using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CanvasScript : MonoBehaviour
{
    [SerializeField] int  tempo;
    [SerializeField] TextMeshProUGUI textosTempo;
    [SerializeField] float segundos = 0;
    [SerializeField] int minutos = 2;

    [SerializeField] GameObject telaDerrota;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        segundos += -Time.deltaTime;
        if(segundos <= 00 && minutos != 0)
        {
            minutos--;
            segundos = 60 -1 ;
        }
        textosTempo.text = minutos.ToString("00")+ ":" + segundos.ToString("00");

        if( minutos == 00 && segundos <= 00)
        {
            perdeu();
        }


    }

    public void perdeu()
    {
        telaDerrota.gameObject.SetActive(true);
        Time.timeScale = 0;
        //Debug.Log("perdeu");
    }
    public void repetir()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void telaPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void Continuar()
    {
        SceneManager.LoadScene(2);
    }

}

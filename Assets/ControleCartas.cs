using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControleCartas : MonoBehaviour
{
    public GameObject jogador;
    public int numAleatorioCartas;
    public int numAleatorioChanse;
    public  GameObject[] cartas;
    public bool tela = false;
    void andarCarta()
    {
        numAleatorioChanse = Random.Range(0,5);
        if(numAleatorioChanse >= 4)
        {
            numAleatorioCartas = Random.Range(0,cartas.Length);
            cartas[numAleatorioCartas].gameObject.SetActive(true);
            tela = true;        
        }


        
    }
    void Update()
    {
        if(Input.GetKeyDown("d"))
        {
            andarCarta();
            //CartaVento();
        }
    }
    public void CartaVento()
    {
        pontuacaoScript flores = jogador.GetComponent<pontuacaoScript>();
        flores.coleta = flores.coleta - 1;
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;  

    }
}

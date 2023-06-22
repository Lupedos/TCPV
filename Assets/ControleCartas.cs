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

    public void andarCarta()//Codigo  que roda  toda vez jogador andar e escolhe  uma carta  aleatoria  entre todas as cartas que tiverem  no  array  cartas
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
       
    }
    public void CartaVento()//Carta vento com suas acoes
    {
        pontuacaoScript flores = jogador.GetComponent<pontuacaoScript>();
        flores.coleta = flores.coleta - 1;
        cartas[numAleatorioCartas].gameObject.SetActive(false);//lembrar de ter isso todas as cartas
        tela = false;//lembrar de ter isso todas as cartas

    }
    public void CartaCuraFlorboa()
    {
        GameObject[] chaoObjects = GameObject.FindGameObjectsWithTag("Flor");
        GameObject florEscolhida = null;
        FlorAnimacao status;
        foreach (GameObject chaoObject in chaoObjects)
        {
            status = chaoObject.GetComponent<FlorAnimacao>();
                if(status.boa == false)
                {
                   florEscolhida = chaoObject;
                   
                }

        }
        status = florEscolhida.GetComponent<FlorAnimacao>();
        status.boa = true;
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }

}
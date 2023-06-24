using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControleCartas : MonoBehaviour
{
    public GameObject jogador;
    public GameObject prefabAranha;
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
        
        if(chaoObjects != null)
        {
            GameObject florEscolhida = null;
            FlorAnimacao status;
            foreach (GameObject chaoObject in chaoObjects)
            {
                status = chaoObject.GetComponent<FlorAnimacao>();
                    if(status.boa == false)
                    {
                    florEscolhida = chaoObject;
                    break;//quebra depois da primeira flor encontrada 
                    }

            }
            if(florEscolhida != null)
            {
                status = florEscolhida.GetComponent<FlorAnimacao>();
                status.boa = true;
            }
            
        }
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }
    public void CartaAranhaFaminta()
    {
        GameObject[] spaws = GameObject.FindGameObjectsWithTag("Spaw");
        int num = Random.Range(0,spaws.Length);

        Instantiate(prefabAranha, spaws[num].transform.position, spaws[num].transform.rotation);
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }
}

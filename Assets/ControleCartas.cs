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
     public void CartaContaminaFlor()
    { 
        GameObject[] chaoObjects = GameObject.FindGameObjectsWithTag("Flor");
        
        if(chaoObjects != null)
        {
            GameObject florEscolhida = null;
            FlorAnimacao status;
            foreach (GameObject chaoObject in chaoObjects)
            {
                status = chaoObject.GetComponent<FlorAnimacao>();
                    if(status.boa == true)
                    {
                    florEscolhida = chaoObject;
                    break;//quebra depois da primeira flor encontrada 
                    }

            }
            if(florEscolhida != null)
            {
                status = florEscolhida.GetComponent<FlorAnimacao>();
                status.boa = false;
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
    public void CartaTornado()// muda  todos os  objetos de lugar 
    {
        // ele  verifica para  nao  repetir mesmo  lugar do  ultimo mas pode acontecer de ir dois objetos para  mesmo lugar 
        GameObject[] chao = GameObject.FindGameObjectsWithTag("chao");
        GameObject[] flores = GameObject.FindGameObjectsWithTag("Flor");
        GameObject[] humanos = GameObject.FindGameObjectsWithTag("Humano");
        GameObject[] aranhas = GameObject.FindGameObjectsWithTag("Aranha");
        int valorPassado = -1;

        foreach(GameObject moveFlor in flores)
        {
            MoverAleatorio script = moveFlor.GetComponent<MoverAleatorio>();
            int num = Random.Range(0,chao.Length);
            if(valorPassado != num)
            {
                script.Moverparachaoperto(chao[num]);
                valorPassado = num;
            }
            else if (valorPassado == num && num != chao.Length)
            {
                script.Moverparachaoperto(chao[num + 1]);
                valorPassado = num;
            }
            else if (valorPassado == num && num == chao.Length)
            {
                script.Moverparachaoperto(chao[num - 1]);
                valorPassado = num;
            }

        }
        foreach(GameObject moveHumano in humanos)
        {
            HumanoScript script = moveHumano.GetComponent<HumanoScript>();
            int num = Random.Range(0,chao.Length);
            if(valorPassado != num)
            {
                script.Moverparachaoperto(chao[num]);
                valorPassado = num;
            }
            else if (valorPassado == num && num != chao.Length)
            {
                script.Moverparachaoperto(chao[num + 1]);
                valorPassado = num;
            }
            else if (valorPassado == num && num == chao.Length)
            {
                script.Moverparachaoperto(chao[num - 1]);
                valorPassado = num;
            }

        }
         foreach(GameObject moveAranha in aranhas)
        {
            AranhaScript script = moveAranha.GetComponent<AranhaScript>();
            int num = Random.Range(0,chao.Length);
            if(valorPassado != num)
            {
                script.Moverparachaoperto(chao[num]);
                valorPassado = num;
            }
            else if (valorPassado == num && num != chao.Length)
            {
                script.Moverparachaoperto(chao[num + 1]);
                valorPassado = num;
            }
            else if (valorPassado == num && num == chao.Length)
            {
                script.Moverparachaoperto(chao[num - 1]);
                valorPassado = num;
            }

        }
            MoveGrid scriptjogador = jogador.GetComponent<MoveGrid>();
            int numJogador = Random.Range(0,chao.Length);
            if(valorPassado != numJogador)
            {
                scriptjogador.TornadoMove(chao[numJogador]);
                valorPassado = numJogador;
            }
            else if (valorPassado == numJogador && numJogador != chao.Length)
            {
                scriptjogador.TornadoMove(chao[numJogador + 1]);
                valorPassado = numJogador;
            }
            else if (valorPassado == numJogador && numJogador == chao.Length)
            {
                scriptjogador.TornadoMove(chao[numJogador - 1]);
                valorPassado = numJogador;
            }


        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }
    public void CartaChuva()
    {
        MoveGrid script = jogador.GetComponent<MoveGrid>();
        script.chuva = true;
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }
    public  void CartaEnegia()
    {
        MoveGrid script = jogador.GetComponent<MoveGrid>();
        script.energia = true;
        cartas[numAleatorioCartas].gameObject.SetActive(false);
        tela = false;
    }

}

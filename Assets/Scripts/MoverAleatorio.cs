using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAleatorio : MonoBehaviour
{
    public GameObject chaoPertoD ;//Direita
    public GameObject chaoPertoE ;//esquerda
    public GameObject chaoPertoC ;//cima
    public GameObject chaoPertoB ;//baixo
    public GameObject chaoPisando;
     
    public ControledeTurno controleDeTurno;
    public int random; 

    void Start()
    {
        //Codigo  para encontrar  chao  mais proximo
       GameObject[] chaoObjects = GameObject.FindGameObjectsWithTag("chao");
       chaoPisando = null;
       float menorDistancia = Mathf.Infinity;
       Vector3 posicaoAtual = transform.position;

       foreach (GameObject chaoObject in chaoObjects)
        {
            float distancia = Vector3.Distance(chaoObject.transform.position, posicaoAtual);
            if (distancia < menorDistancia)
            {
                chaoPisando = chaoObject;
                menorDistancia = distancia;
            }
        }
    }

    
    void Update()
    {
        chaoPertoD = null;
        chaoPertoE = null;
        chaoPertoB = null;
        chaoPertoC = null;
        encontrarChaoPerto(chaoPisando);
        if(controleDeTurno.turnoFlor == true)
        {
            controleDeTurno.MovimentaFlor(false);
            random = Random.Range(1, 5);
            if(random == 1 && chaoPertoD != null)
            {
              //Moverparachaoperto(chaoPertoD);
              StartCoroutine(AndarAleatorio(chaoPertoD)); 
            }
            else if(random == 2 && chaoPertoE != null)
            {
              //Moverparachaoperto(chaoPertoE);
              StartCoroutine(AndarAleatorio(chaoPertoE)); 
            }
            else if(random == 3 && chaoPertoB != null)
            {
              //Moverparachaoperto(chaoPertoB);
              StartCoroutine(AndarAleatorio(chaoPertoB)); 
            }
            else if(random == 4 && chaoPertoC != null)
            {
              //Moverparachaoperto(chaoPertoC);
              StartCoroutine(AndarAleatorio(chaoPertoC)); 
            }
        }
        
    }
    
    IEnumerator AndarAleatorio(GameObject direcao)
    {
        yield return new WaitForSeconds(0.1f);
        Moverparachaoperto(direcao); 
    }


    private void Moverparachaoperto(GameObject chaoPerto)
    {
        if (chaoPerto != null)
        {
            Vector3 position = new Vector3(Mathf.RoundToInt(chaoPerto.transform.position.x), 1.2f, Mathf.RoundToInt(chaoPerto.transform.position.z));
            transform.position = position;
            chaoPisando = chaoPerto;
        }
    }
    private void encontrarChaoPerto(GameObject chao)
    {                          
        string nome = chao.name.Remove(0,4);//EX: Chao1-2  //Remove a partir de 0, 4 letras //EX: 1-2  
        string[] posicao = nome.Split("-");//Split separa 1 do 2 //EX: posicao[0] = 1 e posicao[1] = 2

        int linha = int.Parse(posicao[0]);//1
        int coluna = int.Parse(posicao[1]);//2
        int linhaMais = linha + 1;
        int linhaMenos = linha - 1;
        int colunaMais = coluna + 1;
        int colunaMenos = coluna - 1;

        string chaoPerto_C = "Chao" + (linhaMais).ToString() + "-" + coluna.ToString();//Somando valor da linha
        string chaoPerto_B = "Chao" + (linhaMenos).ToString() + "-" + coluna.ToString();//Diminundo valor da linha
        string chaoPerto_D = "Chao" + linha.ToString() + "-" + (colunaMais).ToString();//Somando valor da coluna
        string chaoPerto_E = "Chao" + linha.ToString() + "-" + (colunaMenos).ToString();//Diminuindo valor da coluna

        //busca novos objetos para Chao
        chaoPertoC = GameObject.Find(chaoPerto_C);
        chaoPertoB = GameObject.Find(chaoPerto_B);
        chaoPertoD = GameObject.Find(chaoPerto_D);
        chaoPertoE = GameObject.Find(chaoPerto_E);

        //Debug.Log("B=" + chaoPerto_B);
        //Debug.Log("C=" + chaoPerto_C);
        //Debug.Log("D=" + chaoPerto_D);
        //Debug.Log("E=" + chaoPerto_E);

    }
}

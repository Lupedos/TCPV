using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveGrid : MonoBehaviour
{
    public GameObject chaoPertoD ;//Direita
    public GameObject chaoPertoE ;//esquerda
    public GameObject chaoPertoC ;//cima
    public GameObject chaoPertoB ;//baixo
    public GameObject chaoPisando;
    
    Playercontrole controle;

    public static bool turno;//caso  turno  seja false  vez jogador  se nao  vez dos inimigos
    public bool Apertou = false;
    void Awake()
    {
      turno = false;//vez do jogador 
      controle = new Playercontrole();

      if(turno == false)//faz com que  jogador  so  ande no  seu  turno 
      {
        controle.Gameplay.Direita.performed += ctx => D();//input direita
        controle.Gameplay.Esquerda.performed += ctx => E();//input esquerda
        controle.Gameplay.Cima.performed += ctx => C();//input cima
        controle.Gameplay.Baixo.performed += ctx => B();//input baixo
      }
      
    } 
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
    void OnEnable()
    {
      controle.Gameplay.Enable();
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
    // Move o personagem para a posição do objeto mais próximo
    private void Moverparachaoperto(GameObject chaoPerto)
    {
        if (chaoPerto != null)
        {
            Vector3 position = new Vector3(Mathf.RoundToInt(chaoPerto.transform.position.x), 0.6f, Mathf.RoundToInt(chaoPerto.transform.position.z));
            transform.position = position;
            chaoPisando = chaoPerto;
            turno = true;
            Apertou = true; 
            //StartCoroutine(TurnoTime());//timer para jogador ter açao  antes dos monstros;
            
        }
    }
    void Update()
    {
        chaoPertoD = null;
        chaoPertoE = null;
        chaoPertoB = null;
        chaoPertoC = null;
        encontrarChaoPerto(chaoPisando);
    }
    void FixedUpdate()
    {
      if(turno == true && Apertou == true)
      {
         StartCoroutine(TurnoAcabou());
         
         Apertou = false;
      }
    }
 
    void D()
    {
      Moverparachaoperto(chaoPertoD);  
    }
    void E()
    {
      Moverparachaoperto(chaoPertoE); 
    }
    void C()
    {
      Moverparachaoperto(chaoPertoC);  
    }
    void B()
    {
      Moverparachaoperto(chaoPertoB); 
    }
    IEnumerator TurnoTime()
    {
      
      yield return new WaitForSeconds(0.03f);
      turno = false;
      
    }
    IEnumerator TurnoAcabou()
    {
      turno = true;
      yield return new WaitForSeconds(0.000000000000000000000000000000000000000000002f);
      turno = false;
    }
}

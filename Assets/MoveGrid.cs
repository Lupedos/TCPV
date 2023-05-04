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

    void Awake()
    {
      controle = new Playercontrole();

               
      controle.Gameplay.Direita.performed += ctx => D();//input direita
      controle.Gameplay.Esquerda.performed += ctx => E();//input esquerda
      controle.Gameplay.Cima.performed += ctx => C();//input cima
      controle.Gameplay.Baixo.performed += ctx => B();//input baixo
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
        }
    }
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));
        chaoPertoD = null;
        chaoPertoE = null;
        chaoPertoB = null;
        chaoPertoC = null;
        encontrarChaoPerto(chaoPisando);
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

}

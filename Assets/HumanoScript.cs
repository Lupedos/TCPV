using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoScript : MonoBehaviour
{
    public GameObject chaoPertoD ;//Direita
    public GameObject chaoPertoE ;//esquerda
    public GameObject chaoPertoC ;//cima
    public GameObject chaoPertoB ;//baixo
    public GameObject chaoPisando;
    private Animator anim;
    
    public int totalLinhas;
    public int totalColunas;

    public MoverAleatorio chaoFlor;
    public FlorAnimacao status;
    public GameObject florPerseguida;
    public ControledeTurno controleDeTurno;
    public GameObject urso;
    public bool ursoViVO;
    public int num;

    void Start()
    {
         anim = GetComponent<Animator>();
        //Debug.Log("iniciou");
        ursoViVO = false;
        ProximaFlor();
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

    private void ProximaFlor()// tudo  fuciona  normal  so  da "erro" quando  nao  tem flor  mas so  para unity 
    {
        GameObject[] florObjects = GameObject.FindGameObjectsWithTag("Flor");
        
        if(florObjects != null)
        {
            Debug.Log("entrou no if FlorObjects do proximaFlor ");
            florObjects = GameObject.FindGameObjectsWithTag("Flor");
            float menorDistancia = Mathf.Infinity;
            Vector3 posicaoAtual = transform.position;

            foreach (GameObject florObject in florObjects)
            {
                float distancia = Vector3.Distance(florObject.transform.position, posicaoAtual);
                status = florObject.GetComponent<FlorAnimacao>();
                if (distancia < menorDistancia)
                {
                    if(status.boa)
                    {
                    florPerseguida = florObject;
                    menorDistancia = distancia;
                    }
                    
                }
            }
            chaoFlor = florPerseguida.GetComponent<MoverAleatorio>();
            status = florPerseguida.GetComponent<FlorAnimacao>();
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
    public void Moverparachaoperto(GameObject chaoPerto)
    {
        if (chaoPerto != null && ursoViVO == false)
        {
            Vector3 position = new Vector3(Mathf.RoundToInt(chaoPerto.transform.position.x), 1f, Mathf.RoundToInt(chaoPerto.transform.position.z));
            transform.position = position;
            chaoPisando = chaoPerto;            
        }
    }

    void Update()
    {
        
        if(chaoPisando == chaoFlor.chaoPisando && ursoViVO == false)
            {
             if(status.boa)
             {
                status.boa = false;
                ProximaFlor();
                anim.SetTrigger("Tocou");
             }
            }
            else if(chaoFlor == null && ursoViVO == false)
            {
                ProximaFlor();
            }
        if(controleDeTurno.turnoHumano == true && ursoViVO == false )
        {
            controleDeTurno.MovimentaHumano(false);
            chaoPertoD = null;
            chaoPertoE = null;
            chaoPertoB = null;
            chaoPertoC = null;
            encontrarChaoPerto(chaoPisando);
            encontrarFlor(chaoFlor.chaoPisando);
        }
       if(controleDeTurno.turnoHumano == true && ursoViVO == true)
        {
            controleDeTurno.MovimentaHumano(false);
            num = Random.Range(0,2);
            if(num == 1)
            {
                
                ursoViVO = false; 
            } 
        }
        if(ursoViVO)
        {
            urso.SetActive(true);
            
        }
        else if(ursoViVO == false)
        {
            urso.SetActive(false);
        }
        
    }

    private void encontrarFlor(GameObject chao)
    {
        string nomeAB = chao.name.Remove(0,4);//EX: Chao1-2  //Remove a partir de 0, 4 letras //EX: 1-2  
        string[] posicao = nomeAB.Split("-");//Split separa 1 do 2 //EX: posicao[0] = 1 e posicao[1] = 2

        string nomeA = chaoPisando.name.Remove(0,4);//EX: Chao1-2  //Remove a partir de 0, 4 letras //EX: 1-2  
        string[] posicao2 = nomeA.Split("-");//Split separa 1 do 2 //EX: posicao[0] = 1 e posicao[1] = 2

        int linhaAB = int.Parse(posicao[0]);//1
        int colunaAB = int.Parse(posicao[1]);//1

        int linhaA = int.Parse(posicao2[0]);//1
        int colunaA = int.Parse(posicao2[1]);//3

        int linhatotal = Mathf.Abs(linhaA - linhaAB);  //linhaA - linhaAB;
        int colunatotal =  Mathf.Abs(colunaA - colunaAB);   //colunaA - colunaAB;
         
        
        if( linhatotal >= colunatotal)
        {
            //Debug.Log("Linhatotal: " + linhatotal + "Colunatotal: " + colunatotal + "linhaA: " + linhaA + "linhaAB: " + linhaAB);
            if(linhaA == 1 && linhaA != linhaAB)
            {
                //Debug.Log("Cima-linhaA: " + linhaA + " linhaAB: " + linhaAB);
                Moverparachaoperto(chaoPertoC);
            }
            else if(linhaA == totalLinhas &&  linhaA != linhaAB)
            {
                //Debug.Log("Baixo-linhaA: " + linhaA + " linhaAB: " + linhaAB);
                Moverparachaoperto(chaoPertoB);
            }
            else if(linhaA > linhaAB)
            {
               //Debug.Log("Baixo2-linhaA: " + linhaA + " linhaAB: " + linhaAB);
                Moverparachaoperto(chaoPertoB);
            }
            else if(linhaA < linhaAB)
            {
                //Debug.Log("Cima2-linhaA: " + linhaA + " linhaAB: " + linhaAB);
                Moverparachaoperto(chaoPertoC);
            }
        }
        else if( linhatotal < colunatotal )
        {
            //Debug.Log("Linhatotal2: " + linhatotal + "Colunatotal2: " + colunatotal+ "colunaA: " + colunaA + "colunaAB: " + colunaAB);
            if(colunaA == 1 && colunaA != colunaAB)
            {
                //Debug.Log("Direita-ColunaA: " + colunaA + " ColunaAB: " + colunaAB);
                Moverparachaoperto(chaoPertoD);
            }
            else if(colunaA == totalColunas && colunaA != colunaAB)
            {
                //Debug.Log("Esquerda-ColunaA: " + colunaA + " ColunaAB: " + colunaAB);    
                Moverparachaoperto(chaoPertoE);
            }
            else if(colunaA > colunaAB)
            {
                //Debug.Log("Esquerda2-ColunaA: " + colunaA + " ColunaAB: " + colunaAB);
                Moverparachaoperto(chaoPertoE);
            }
            else if(colunaA < colunaAB)
            {
                //Debug.Log("Direita2-ColunaA: " + colunaA + " ColunaAB: " + colunaAB);
                Moverparachaoperto(chaoPertoD);
            }
        }


    }
}

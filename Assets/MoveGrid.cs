using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrid : MonoBehaviour
{
    
    public GameObject[] chaos; 
    [SerializeField] Vector3 titlePos ;
    GameObject objetoMaisProximo = null;
    float distanciaMaisProxima = Mathf.Infinity;
    public GameObject chaoPisando;
    
    void Start()
    {
      chaos = GameObject.FindGameObjectsWithTag("chao");       
    }

    
    void Update()
    {
        
         for ( int i = 0; i < chaos.Length; i++) 
         {
            if (chaos[i].transform.position.x > transform.position.x && chaos[i].transform.position.z == transform.position.z &&  chaos[i] != chaoPisando ) 
            {
                 float distancia = Vector3.Distance(transform.position, chaos[i].transform.position);

                   if (distancia < distanciaMaisProxima) 
                   {
                     objetoMaisProximo = chaos[i];
                     distanciaMaisProxima = distancia;
                     Debug.Log(objetoMaisProximo);

                   }

             titlePos = new Vector3(Mathf.RoundToInt(objetoMaisProximo.transform.position.x),0.6f,Mathf.RoundToInt(objetoMaisProximo.transform.position.z));
             
                
            }
        }
        if(Input.GetKeyDown("d"))
        {
           
          this.transform.position = titlePos;
          chaoPisando = objetoMaisProximo;
        }
        
    }
}

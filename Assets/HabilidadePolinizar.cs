using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HabilidadePolinizar : MonoBehaviour
{
    Playercontrole controle;
    public List<GameObject> flores = new List<GameObject>();
    public ControledeTurno controleDeTurno;
    void Awake()
    {
        controle = new Playercontrole();
        controle.Gameplay.Polinizar.performed += ctx => PolinizarFlores();//input A butao da  direita 

    }
    void Update()
    {
        flores.Remove(null);
    }
    void OnEnable()
    {
      controle.Gameplay.Enable();
    }
     public void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Flor")
        {
            //flores = other.gameObject;
            flores.Add(other.gameObject);
            
        }
    }
     public void OnTriggerExit(Collider other)
    {
         if (other.tag == "Flor")
        {
            flores.Remove(other.gameObject);
            
        }
    }     

    public void PolinizarFlores()
    {
        //FlorAnimacao[] flor = flores.GetComponent<FlorAnimacao>();
        //FlorAnimacao[] flor = flores.ToArray.GetComponent<FlorAnimacao>();
        //Debug.Log("Apertou");
        GameObject[] flor = flores.ToArray();
        foreach (GameObject planta in flor)
        {
            FlorAnimacao florComponente = planta.GetComponent<FlorAnimacao>();
            if (florComponente != null && !florComponente.boa)
            {
                florComponente.boa = true;
                //Debug.Log("entrou");
            }
        }
        controleDeTurno.MovimentaTodos(true);


    } 
        
}

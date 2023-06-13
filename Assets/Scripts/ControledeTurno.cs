using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeTurno : MonoBehaviour
{
    public bool turnoAranha;
    public GameObject[] aranhas;
    public int numTurnosAranhas;

    public bool turnoHumano;
    public GameObject[] humanos;
    public int  numTurnosHumanos;


    public bool turnoFlor;
    public GameObject[] flores;
    public int numturnos; 
    void Start()
    {
        flores = GameObject.FindGameObjectsWithTag("Flor");
        numturnos = flores.Length;

        aranhas = GameObject.FindGameObjectsWithTag("Aranha");
        numTurnosAranhas = aranhas.Length;

        humanos = GameObject.FindGameObjectsWithTag("Humano");
        numTurnosHumanos = humanos.Length;
    }

   
    void Update()
    {
        flores = GameObject.FindGameObjectsWithTag("Flor");
        aranhas = GameObject.FindGameObjectsWithTag("Aranha");
        humanos = GameObject.FindGameObjectsWithTag("Humano");
    }

    public void MovimentaTodos(bool valor)
    {
        turnoAranha = valor;
        turnoFlor = valor;
        turnoHumano = valor;
    }

    public void MovimentaAranha(bool valor)
    {
        numTurnosAranhas--;
        if(numTurnosAranhas <= 0)
        {
            numTurnosAranhas = aranhas.Length;
            turnoAranha = valor;
        }
        
    }

    public void MovimentaFlor(bool valor)
    {
        numturnos--; 
        if(numturnos <= 0)
        {
            numturnos = flores.Length;
            turnoFlor = valor;
        }
        
    }

    public void MovimentaHumano(bool valor)
    {
        numTurnosHumanos--;
        if(numTurnosHumanos <= 0)
        {
            numTurnosHumanos = humanos.Length;
            turnoHumano = valor;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeTurno : MonoBehaviour
{
    public bool turnoAranha;
    public bool turnoFlor;
    public bool turnoHumano;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void MovimentaTodos(bool valor)
    {
        turnoAranha = valor;
        turnoFlor = valor;
        turnoHumano = valor;
    }

    public void MovimentaAranha(bool valor)
    {
        turnoAranha = valor;
    }

    public void MovimentaFlor(bool valor)
    {
        turnoFlor = valor;
    }

    public void MovimentaHumano(bool valor)
    {
        turnoHumano = valor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int altura;
    [SerializeField] private Transform jogador;
    [SerializeField] private Transform grid;//chao
    [SerializeField] private GameObject[] grids;//conjunto de chao 
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void  Update()
    {
        Vector3 quadPos = Vector3.up * altura;
        grid.position = quadPos;  
        //faz o  chao  ficar no  valor da altura

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, 1000f))
            {
                    Vector3 titlePos = new Vector3(Mathf.RoundToInt(hit.point.x), altura + 0.6f,Mathf.RoundToInt(hit.point.z));

                    if (hit.collider != null)
                    {
                        jogador.position = titlePos;
                    }
            }

        }
    }
}

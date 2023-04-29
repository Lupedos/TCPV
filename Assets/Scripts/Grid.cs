using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int altura;
    [SerializeField] private Transform jogador;
  
    [SerializeField] private List<GameObject> grids;//conjunto de chao 
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void  Update()
    {
        
       

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, 1000f))
            {
                    Vector3 titlePos = new Vector3(Mathf.RoundToInt(hit.point.x), altura + 0.6f,Mathf.RoundToInt(hit.point.z));//coloca na variavel o posiçao do click
                    if (hit.collider != null && hit.collider.tag == "chao" && grids.Contains(hit.collider.gameObject))// verifica se colidiu  em algo  que é chao
                    {
                        jogador.position = titlePos;// vai  pra  posiçao  da variavel 
                    }
            }

        }
    }
}

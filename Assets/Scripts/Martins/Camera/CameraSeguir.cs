using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{

public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.01f);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorAnimacao : MonoBehaviour
{
    public bool boa; 
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(boa)
        {
            anim.SetBool("florBoa", true);
        }
        else if(boa == false)
        {
            anim.SetBool("florBoa", false);
        }



    }
}

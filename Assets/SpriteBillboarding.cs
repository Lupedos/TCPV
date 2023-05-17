using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboarding : MonoBehaviour
{
    [SerializeField] bool congelarX = true;

    private void Update()
    {
      if(congelarX)
      {
        transform.rotation = Quaternion.Euler(0f,Camera.main.transform.rotation.eulerAngles.y, 0f);
      }
      else
      {
        transform.rotation = Camera.main.transform.rotation;
      }
        


    }
}

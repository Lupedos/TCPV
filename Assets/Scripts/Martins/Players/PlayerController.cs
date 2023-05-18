using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

public Rigidbody rig;
public float moveSpeed, jumpForce;

private Vector2 moveInput;

public LayerMask whaitIsGround;
public Transform groundPoint;
private bool isGrounded;

public SpriteRenderer fliparPerson;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

       moveInput.x = Input.GetAxis("Horizontal");
       moveInput.y = Input.GetAxis("Vertical");
       moveInput.Normalize();

       rig.velocity = new Vector3(moveInput.x * moveSpeed, rig.velocity.y, moveInput.y * moveSpeed);

       RaycastHit hit;
       if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whaitIsGround)){

        isGrounded = true;
       }else{
        isGrounded = false;
       }

       if(Input.GetButtonDown("Jump") && isGrounded){
        rig.velocity += new Vector3(0f, jumpForce, 0f);
       }

       if(!fliparPerson.flipX && moveInput.x <0)
    {
        fliparPerson.flipX = true;

    }else if(fliparPerson.flipX && moveInput.x > 0)
    {
        fliparPerson.flipX = false;
    }


        
    }
}

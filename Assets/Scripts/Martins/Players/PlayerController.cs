using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed, jumpForce;
    public Animator anim;
    private Vector2 moveInput;

    public LayerMask whaitIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    public SpriteRenderer fliparPerson;
    public GameObject painelJogo;
    public GameObject painelJogo2;
    public GameObject painelJogo3;
    public GameObject painelJogo4;
    public GameObject painelJogo5;
    public GameObject menuPanel;
    private bool isMenuOpen = false;

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("aa"))
        {
            AbrirPainel();
            PausarJogo();

        }
        if (other.CompareTag("tartaruga"))
        {
            AbrirPainel2();
            PausarJogo();

        }

        if (other.CompareTag("macaco"))
        {
            AbrirPainel3();
            PausarJogo();

        }

         if (other.CompareTag("sagui"))
        {
            AbrirPainel4();
            PausarJogo();

        }

        if (other.CompareTag("papagaio"))
        {
            AbrirPainel5();
            PausarJogo();

        }

    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("aa"))
    //     {
    //         SceneManager.LoadScene("Gameplay");
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogador pressionou a tecla ESC ou o botão Start no controle
        if (Input.GetButtonDown("Cancel"))
        {
            isMenuOpen = !isMenuOpen; // Alterna entre abrir e fechar o painel

            // Ativa ou desativa o painel do menu
            menuPanel.SetActive(isMenuOpen);


            // Pausa ou retoma o jogo (desabilita ou habilita o script de controle do jogador)
            enabled = !isMenuOpen;
        }

        if (!isMenuOpen)
        {
            // Obtem as entradas de movimento
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            moveInput.Normalize();
            
            

            // Move o jogador
            rig.velocity = new Vector3(moveInput.x * moveSpeed, rig.velocity.y, moveInput.y * moveSpeed);

            //animator
            if(moveInput.x != 0 || moveInput.y != 0)
            {
                anim.SetBool("movendo" , true); 
            }
            else
            {
                anim.SetBool("movendo" , false); 
            }

            // Verifica se o jogador está no chão
            RaycastHit hit;
            if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whaitIsGround))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            // Verifica se o jogador pressionou a tecla de espaço e está no chão
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rig.velocity += new Vector3(0f, jumpForce, 0f);
            }

            // Inverte a direção do personagem caso esteja se movendo para a esquerda
            if (!fliparPerson.flipX && moveInput.x < 0)
            {
                fliparPerson.flipX = true;
            }
            else if (fliparPerson.flipX && moveInput.x > 0)
            {
                fliparPerson.flipX = false;
            }
        }

       


    }

        public void AbrirPainel()
        {
            painelJogo.SetActive(true);
        }

        public void FecharPainel()
        {
            painelJogo.SetActive(false);
        }

        private void PausarJogo()
       {
            Time.timeScale = 0f;
       }

        public void RetomarJogo()
       {
        Time.timeScale = 1f;
       }

       public void AbrirPainel2()
       {
            painelJogo2.SetActive(true);
       }

        public void FecharPainel2()
        {
        painelJogo2.SetActive(false);
        }

         public void AbrirPainel3()
        {
            painelJogo3.SetActive(true);
        }

        public void FecharPainel3()
        {
            painelJogo3.SetActive(false);
        }

        public void AbrirPainel4()
        {
            painelJogo4.SetActive(true);
        }

        public void FecharPainel4()
        {
            painelJogo4.SetActive(false);
        }

        public void AbrirPainel5()
        {
            painelJogo5.SetActive(true);
        }

        public void FecharPainel5()
        {
            painelJogo5.SetActive(false);
        }
}








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

    public GameObject menuPanel;
    private bool isMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {

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
}








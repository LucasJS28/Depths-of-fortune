using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float runSpeed = 2;
    public float jumpSpeed = 8;
    public bool isGrounded = false;
    private Camera mainCamera;
    public float cameraOffsetY = 1.0f; // Ajuste de posición Y de la cámara
    private Controlador controlador; // Referencia al script del contador


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        controlador = GameObject.FindObjectOfType<Controlador>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Atacar",true);
        }else{
            animator.SetBool("Atacar",false);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX=false; // Gira al Personaje
            animator.SetBool("Run",true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX=true; // Gira al Personaje
            animator.SetBool("Run",true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run",false);
        }

        // Saltar si el jugador está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if(isGrounded==false){
            animator.SetBool("Run",false);
            animator.SetBool("Jump",true);
        }
        if(isGrounded==true){
        
            animator.SetBool("Jump",false);
        }

        if (mainCamera != null)
        {
            Vector3 nuevaPosicionCamara = transform.position;
            nuevaPosicionCamara.z = mainCamera.transform.position.z; // Mantener la posición Z de la cámara
            nuevaPosicionCamara.y += cameraOffsetY; // Ajuste de posición Y de la cámara
            mainCamera.transform.position = nuevaPosicionCamara;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo"))
        {
            isGrounded = true; // El jugador está en el suelo
        }
        if (collision.CompareTag("agua"))
        {
            Debug.Log("Has Muerto -1 Vida");
            controlador.RestarVida(1); // Suma la moneda al contador
        }
        
        if (collision.CompareTag("muerte"))
        {
            Debug.Log("Has Muerto -1 Vida");
            controlador.RestarVida(1); // Suma la moneda al contador
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo"))
        {
            isGrounded = false; // El jugador ya no está en el suelo
        }
    }

}
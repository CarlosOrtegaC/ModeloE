using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movementInput;
    private Rigidbody2D rb2D;
    private Animator animator;
    private Vector2 playerDirection;
    public bool hasKey = false;
    public int vida = 100; // 🩸 empieza con 100 de vida
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject gameOverPanel;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movimiento();
        AnimacionPersonaje();
        LimitesMapa();
    }

    private void AnimacionPersonaje()
    {
        if (movementInput != Vector2.zero)
        {
            playerDirection = movementInput;
        }
        animator.SetFloat("Horizontal", playerDirection.x);
        animator.SetFloat("Vertical", playerDirection.y);
        animator.SetFloat("Speed", movementInput.magnitude);
    }

    private void Movimiento()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(movementInput.x, movementInput.y).normalized;
    }

    private void LimitesMapa()
    {
        float limitX = Mathf.Clamp(rb2D.position.x, -8.5f, 8.5f);
        float limitY = Mathf.Clamp(rb2D.position.y, -4.5f, 4.5f);
        rb2D.position = new Vector2(limitX, limitY);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = movementInput * speed;
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("El jugador ha recibido daño. Vida actual: " + vida);

        if(vida <= 0)
        {
            Perder();
            Debug.Log("El jugador ha muerto.");
        }
        else
        {
            StartCoroutine(ParpadeoRojo());
        }
    }

    // 🔴 Corutina simple de parpadeo
    private IEnumerator ParpadeoRojo()
    {
        for (int i = 0; i < 3; i++) // 3 parpadeos → 1.5s aprox
        {
            spriteRenderer.color = Color.red;   // se pone rojo
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = Color.white; // vuelve al normal
            yield return new WaitForSeconds(0.25f);
        }
    }
    private void Perder()
    {
        Debug.Log("¡Has perdido!");
        Destroy(gameObject); // destruir jugador

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); // mostrar panel
    }
}

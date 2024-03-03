using UnityEngine;

public class ControlMovimiento : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento lateral
    public float jumpForce = 5f; // Fuerza del salto
    public int maxJumps = 2; // N�mero m�ximo de saltos permitidos
    private int jumpsRemaining; // Saltos restantes
    private bool isGrounded; // Flag para saber si el jugador est� en el suelo
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator; // Referencia al controlador de animaci�n
    private bool isRunning = false; // Estado de correr
    private bool doubleJumped = false; // Flag para el doble salto
    public AudioSource jumpSound; // Referencia al audio del salto

    void Start()
    {
        jumpsRemaining = maxJumps; // Al inicio, el jugador tiene el m�ximo de saltos disponibles
    }

    void Update()
    {
        // Movimiento lateral
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Voltear el sprite seg�n la direcci�n del movimiento
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true; // Voltear hacia la izquierda
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false; // Voltear hacia la derecha
        }

        // Actualizar el estado de correr para la animaci�n
        isRunning = Mathf.Abs(horizontalInput) > 0;

        // Actualizar el par�metro de animaci�n
        animator.SetBool("IsRunning", isRunning);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsRemaining > 0) // Si hay saltos restantes
            {
                if (jumpsRemaining == maxJumps || isGrounded) // Si es el primer salto o est� en el suelo
                {
                    Jump();
                }
                else if (!doubleJumped) // Si no quedan saltos y a�n no se ha realizado un doble salto
                {
                    DoubleJump();
                }
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsRemaining--; // Restar un salto
        doubleJumped = false; // Reiniciar el flag de doble salto
        PlayJumpSound(); // Llamar al m�todo para reproducir el sonido del salto
    }

    void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        doubleJumped = true;
        animator.SetBool("DoubleJump", true); // Activar la animaci�n de doble salto
        PlayJumpSound(); // Llamar al m�todo para reproducir el sonido del salto
    }

    void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            jumpSound.Play(); // Reproducir el sonido del salto si hay un AudioSource asignado
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TileMap")) // Cuando colisiona con el suelo
        {
            jumpsRemaining = maxJumps; // Reiniciar los saltos disponibles
            doubleJumped = false; // Reiniciar el flag de doble salto
            animator.SetBool("DoubleJump", false); // Desactivar la animaci�n de doble salto
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TileMap")) // Cuando deja de colisionar con el suelo
        {
            isGrounded = false;
        }
    }
}


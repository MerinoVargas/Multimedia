using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto
    public Rigidbody2D rb;
    private Vector2 originalVelocity; // Velocidad original del personaje

    void Start()
    {
        originalVelocity = rb.velocity; // Almacenar la velocidad original del personaje
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Verificar si se presiona la tecla de espacio
        {
            Jump(); // Llamar a la función Jump
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce; // Aplicar fuerza hacia arriba al Rigidbody2D

        // Restaurar la velocidad original después del salto
        rb.velocity = new Vector2(rb.velocity.x, originalVelocity.y);
    }
}

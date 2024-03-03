using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento del enemigo
    public Vector2 direccion = Vector2.left; // Direcci�n de movimiento del enemigo

    void Update()
    {
        // Mover el enemigo en la direcci�n especificada
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}

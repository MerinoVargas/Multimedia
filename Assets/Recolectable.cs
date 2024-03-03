using UnityEngine;
using TMPro;

public class Recolectable : MonoBehaviour
{
    public TMP_Text textoPuntuacion; // Referencia al texto que muestra la puntuación
    private static int puntuacion = 0; // Puntuación actual

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementar la puntuación
            puntuacion++;

            // Actualizar el texto de puntuación
            if (textoPuntuacion != null)
            {
                // Asignar directamente el valor de la puntuación al texto
                textoPuntuacion.text = puntuacion.ToString();
            }

            // Destruir este objeto recolectable
            Destroy(gameObject);
        }
    }
}


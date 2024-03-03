using UnityEngine;
using TMPro;

public class Recolectable : MonoBehaviour
{
    public TMP_Text textoPuntuacion; // Referencia al texto que muestra la puntuaci�n
    private static int puntuacion = 0; // Puntuaci�n actual

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementar la puntuaci�n
            puntuacion++;

            // Actualizar el texto de puntuaci�n
            if (textoPuntuacion != null)
            {
                // Asignar directamente el valor de la puntuaci�n al texto
                textoPuntuacion.text = puntuacion.ToString();
            }

            // Destruir este objeto recolectable
            Destroy(gameObject);
        }
    }
}


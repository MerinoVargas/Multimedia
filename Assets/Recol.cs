using UnityEngine;
using TMPro;

public class Recol : MonoBehaviour
{
    public TMP_Text textoPuntuacion2; // Referencia al texto que muestra la puntuación
    private static int puntuacion2 = 0; // Puntuación actual

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementar la puntuación
            puntuacion2++;

            // Actualizar el texto de puntuación
            if (textoPuntuacion2 != null)
            {
                // Asignar directamente el valor de la puntuación al texto
                textoPuntuacion2.text = puntuacion2.ToString();
            }

            // Destruir este objeto recolectable
            Destroy(gameObject);
        }
    }
}


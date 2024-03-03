using UnityEngine;
using TMPro;

public class Recol : MonoBehaviour
{
    public TMP_Text textoPuntuacion2; // Referencia al texto que muestra la puntuaci�n
    private static int puntuacion2 = 0; // Puntuaci�n actual

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementar la puntuaci�n
            puntuacion2++;

            // Actualizar el texto de puntuaci�n
            if (textoPuntuacion2 != null)
            {
                // Asignar directamente el valor de la puntuaci�n al texto
                textoPuntuacion2.text = puntuacion2.ToString();
            }

            // Destruir este objeto recolectable
            Destroy(gameObject);
        }
    }
}


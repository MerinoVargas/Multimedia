using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionEnemigo : MonoBehaviour
{
    public Image[] corazones; // Array de imágenes de corazón
    private int vidasRestantes;

    void Start()
    {
        vidasRestantes = corazones.Length; // Inicializar vidas restantes al número de imágenes de corazón
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restar una vida
            vidasRestantes--;

            // Destruir la imagen de corazón correspondiente
            if (vidasRestantes >= 0 && vidasRestantes < corazones.Length)
            {
                Destroy(corazones[vidasRestantes].gameObject);
            }

            // Si se quedan 0 vidas, destruir al jugador
            if (vidasRestantes <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionEnemigo : MonoBehaviour
{
    public Image[] corazones; // Array de im�genes de coraz�n
    private int vidasRestantes;

    void Start()
    {
        vidasRestantes = corazones.Length; // Inicializar vidas restantes al n�mero de im�genes de coraz�n
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restar una vida
            vidasRestantes--;

            // Destruir la imagen de coraz�n correspondiente
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
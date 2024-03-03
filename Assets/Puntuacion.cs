using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public int puntuacionMaxima = 0; // La puntuación máxima
    internal string text;
    private int puntuacionActual = 0; // La puntuación actual

    public void AumentarPuntuacion(int puntos)
    {
        puntuacionActual += puntos;
        if (puntuacionActual > puntuacionMaxima)
        {
            puntuacionMaxima = puntuacionActual;
            Debug.Log("¡Nuevo récord de puntuación máxima alcanzado: " + puntuacionMaxima + "!");
            if (puntuacionActual == puntuacionMaxima)
            {
                Debug.Log("¡Felicidades! Has alcanzado la puntuación máxima.");
            }
        }
        else
        {
            Debug.Log("Puntuación actual: " + puntuacionActual);
        }
    }
}

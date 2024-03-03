using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public int puntuacionMaxima = 0; // La puntuaci�n m�xima
    internal string text;
    private int puntuacionActual = 0; // La puntuaci�n actual

    public void AumentarPuntuacion(int puntos)
    {
        puntuacionActual += puntos;
        if (puntuacionActual > puntuacionMaxima)
        {
            puntuacionMaxima = puntuacionActual;
            Debug.Log("�Nuevo r�cord de puntuaci�n m�xima alcanzado: " + puntuacionMaxima + "!");
            if (puntuacionActual == puntuacionMaxima)
            {
                Debug.Log("�Felicidades! Has alcanzado la puntuaci�n m�xima.");
            }
        }
        else
        {
            Debug.Log("Puntuaci�n actual: " + puntuacionActual);
        }
    }
}

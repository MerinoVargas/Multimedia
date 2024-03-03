using UnityEngine;
using UnityEngine.UI;

public class AgregarComponenteImage : MonoBehaviour
{
    void Start()
    {
        // Verificar si el componente Image ya está adjunto
        Image imagen = GetComponent<Image>();

        // Si no se encuentra el componente Image, agregarlo
        if (imagen == null)
        {
            // Agregar el componente Image
            imagen = gameObject.AddComponent<Image>();
            // Aquí podrías configurar propiedades de la imagen si es necesario, como sprite, color, etc.
        }
    }
}

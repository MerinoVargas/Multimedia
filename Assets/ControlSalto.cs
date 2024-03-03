using UnityEngine;

public class ControlSalto : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    public LayerMask sueloLayer;
    public int limiteSaltos = 2; // Número máximo de saltos consecutivos

    private Rigidbody2D rb;
    private bool enSuelo = false;
    private int saltosRealizados = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && saltosRealizados < limiteSaltos && (enSuelo || saltosRealizados > 0))
        {
            Saltar();
        }

        // Verificar si el personaje está en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, sueloLayer);
        enSuelo = hit.collider != null;

        // Reiniciar el contador de saltos cuando el personaje toca el suelo
        if (enSuelo)
        {
            saltosRealizados = 0;
        }
    }

    void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reiniciar la velocidad vertical
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        saltosRealizados++;
    }
}

using UnityEngine;

public class Objetos : MonoBehaviour
{
    public float grabRange = 1.5f; // Rango de agarre
    public Transform holdPosition; // Posición donde se sostiene el objeto
    private GameObject grabbedObject; // Objeto actualmente agarrado

    void Update()
    {
        // Agarrar objeto
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedObject == null)
            {
                Grab();
            }
            else
            {
                Release();
            }
        }
    }

    void Grab()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, grabRange);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Frutas"))
            {
                grabbedObject = col.gameObject;
                grabbedObject.transform.position = holdPosition.position;
                break;
            }
        }
    }

    void Release()
    {
        if (grabbedObject != null)
        {
            grabbedObject = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}

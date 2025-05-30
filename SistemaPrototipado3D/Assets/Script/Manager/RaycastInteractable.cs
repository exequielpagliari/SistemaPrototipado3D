using UnityEngine;
using Prototipe.Core.Interfaces;
/// <summary>
/// Clase dedicada a disparar un Raycast hacia abajo para detectar Ground.
/// </summary>
public class RaycastInteractable : MonoBehaviour
{
    /// <summary>
    /// Máscara para detectar en el Raycast.
    /// </summary>
    public LayerMask interactableMask;
    /// <summary>
    /// Distancia de detección del Raycast.
    /// </summary>
    public float CheckDistance = 1f;

    public IInteractable interactable;
    public bool testRay;
    private Collider col;

    RaycastHit hit;
    IInteractable lastHit;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    /// <summary>
    /// Método que llama a la deteccion del Raycast.
    /// </summary>
    public bool IsInteractable()
    {
        Vector3 origin = new Vector3(transform.position.x, col.bounds.center.y, transform.position.z);
        
        return Physics.Raycast (origin, Vector3.left, out hit, CheckDistance, interactableMask);
    }

    public IInteractable GetInteractable()
    {
        lastHit = hit.collider.gameObject.GetComponentInParent<IInteractable>(); ;
        return hit.collider.gameObject.GetComponentInParent<IInteractable>();
    }

    public IInteractable GetLastInteractable()
    {
        return lastHit;
    }    

    public void EraseLastInteractable()
    { lastHit = null; }

    private void Update()
    {
        if (testRay)
        {
            Debug.DrawRay(transform.position, Vector3.left * CheckDistance, Color.green);
        }
    }
}

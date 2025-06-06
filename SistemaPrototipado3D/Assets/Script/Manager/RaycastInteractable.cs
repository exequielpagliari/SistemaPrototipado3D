using UnityEngine;
using Prototipe.Core.Interfaces;


/// <summary>
/// Clase dedicada a disparar un Raycast para detectar Interactables.
/// </summary>
public class RaycastInteractable : MonoBehaviour
{
    /// <summary>
    /// M�scara Interactable para detectar en el Raycast.
    /// </summary>
    public LayerMask interactableMask;
    /// <summary>
    /// Distancia de detecci�n del Raycast.
    /// </summary>
    public float CheckDistance = 1f;

    /// <summary>
    /// Referencia a c�mara para disparar rayo desde su proyecci�n.
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// Referencia de interactable detectado.
    /// </summary>
    public IInteractable interactable;

    /// <summary>
    /// Bool para iniciar el proceso de debug.
    /// </summary>
    public bool testRay;
    /// <summary>
    /// Referencia del collider para disparar Raycast.
    /// </summary>
    private Collider col;
    /// <summary>
    /// Vector para delimitar el origen del Raycast.
    /// </summary>
    private Vector3 origin;
    /// <summary>
    /// Referencia del hit del raycast para manipular.
    /// </summary>
    RaycastHit hit;
    /// <summary>
    /// Referencia del �ltico Interactable impactado por el Raycast.
    /// </summary>
    IInteractable lastHit;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    /// <summary>
    /// M�todo que llama a la deteccion del Raycast.
    /// </summary>
    public bool IsInteractable()
    {
        if (mainCamera)
        {
            origin = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            return Physics.Raycast(mainCamera.ScreenPointToRay(origin), out hit, CheckDistance, interactableMask);
        }
        else
        {
            origin = new Vector3(transform.position.x, col.bounds.center.y, transform.position.z);
            return Physics.Raycast(origin, Vector3.left, out hit, CheckDistance, interactableMask);
        }
    }

    /// <summary>
    /// M�todo para obtener la referencia del Interactable.
    /// </summary>
    public IInteractable GetInteractable()
    {
        lastHit = hit.collider.gameObject.GetComponentInParent<IInteractable>(); ;
        return hit.collider.gameObject.GetComponentInParent<IInteractable>();
    }

    /// <summary>
    /// M�todo para obtener la referencia del �ltimo Interactable.
    /// </summary>
    public IInteractable GetLastInteractable()
    {
        return lastHit;
    }

    /// <summary>
    /// M�todo para borrar la referencia del Interactable.
    /// </summary>
    public void EraseLastInteractable()
    { lastHit = null; }

    private void Update()
    {
        if (testRay)
        {
            if (mainCamera)
            {
                Debug.DrawRay(mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).origin, mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).direction, Color.green);
            }
            else
            { 
                Debug.DrawRay(transform.position, Vector3.left * CheckDistance, Color.green);
            }
        }
    }
}

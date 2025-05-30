using UnityEngine;

/// <summary>
/// Clase dedicada a la manipualación de RaycastInteractable.
/// </summary>
public class InteractionRaycast : MonoBehaviour
{
    /// <summary>
    /// Referencia a RaycastInteractable.
    /// </summary>
    RaycastInteractable raycastInteractable;
    /// <summary>
    /// Referencia a InteractableManager.
    /// </summary>
    InteractableManager interactableManager;
    /// <summary>
    /// Booleano para hacer test de Raycast.
    /// </summary>
    public bool testRay;
    private void Start()
    {
        interactableManager = GetComponent<InteractableManager>();
        raycastInteractable = GetComponent<RaycastInteractable>();
    }

    private void Update()
    {
        if (interactableManager.raycastInteraction)
        {
            if (raycastInteractable.IsInteractable() == true && raycastInteractable.GetLastInteractable() == null)
            {
                if (testRay)
                    Debug.Log("Interactable");
                Debug.Log(raycastInteractable.GetInteractable());
                interactableManager.RegisterInteractable(raycastInteractable.GetInteractable());
            }

            if (raycastInteractable.IsInteractable() == false && raycastInteractable.GetLastInteractable() != null)
            {
                interactableManager.UnregisterInteractable(raycastInteractable.GetLastInteractable());
                raycastInteractable.EraseLastInteractable();
            }


        }
    }

}

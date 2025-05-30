using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{
    RaycastInteractable raycastInteractable;
    InteractableManager interactableManager;
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

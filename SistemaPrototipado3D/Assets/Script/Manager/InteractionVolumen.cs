using Prototipe.Core.Interfaces;
using UnityEngine;

public class InteractionVolumen : MonoBehaviour
{
    public InteractableManager interactableManager;
    private void Start()
    {
        interactableManager = GetComponent<InteractableManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!interactableManager.raycastInteraction && other.TryGetComponent<IInteractable>(out var interactable))
        {
            interactableManager.RegisterInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!interactableManager.raycastInteraction && other.TryGetComponent<IInteractable>(out var interactable))
        {
            interactableManager.UnregisterInteractable(interactable);
        }
    }
}

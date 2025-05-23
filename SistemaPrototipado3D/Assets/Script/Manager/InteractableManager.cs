using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase dedicada a la manipualación de IActivators en el Actor.
/// </summary>
public class InteractableManager : MonoBehaviour
{
    public IInteractable currentInteractable;
    /// <summary>
    /// UI dedicada a la representación de interacción.
    /// </summary>
    public GameObject UI;
    public Text text;

    /// <summary>
    /// Se subscribe como posible activador.
    /// </summary>
    /// <param name="interactable">Un objeto del tipo Interactable a registrar.</param>

    private void OnEnable()
    {
        text = UI.GetComponent<Text>();
    }


    public void RegisterInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;
        text.text = interactable.GetInteractionPrompt();
        UI.SetActive(true);
    }

    /// <summary>
    /// Se desubscribe como posible activador.
    /// </summary>
    /// <param name="interactable">Un objeto del tipo Interactable a desregistrar.</param>
    public void UnregisterInteractable(IInteractable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;
            UI.SetActive(false);
        }
    }

    private void Update()
    {
        DetectActivator();
    }

    void DetectActivator()
    {
        if (InputManager.Instance.InteractPressed)
        {
            currentInteractable?.Interact();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            RegisterInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            UnregisterInteractable(interactable);
        }
    }
}

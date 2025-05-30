using UnityEngine;
using UnityEngine.UI;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a la manipualación de Interactables.
/// </summary>
public class InteractableManager : MonoBehaviour
{
    /// <summary>
    /// Referencia de actual Interactable.
    /// </summary>
    public IInteractable currentInteractable;
    /// <summary>
    /// Referencia a InteractableVolumen.
    /// </summary>
    public InteractionVolumen interactionVolumen;
    /// <summary>
    /// Referencia a InteractionRaycast.
    /// </summary>
    public InteractionRaycast interactionRaycast;
    /// <summary>
    /// Booleano para configurar interacción por Raycast.
    /// </summary>
    public bool raycastInteraction;



    private void Start()
    {
        interactionRaycast.GetComponent<InteractionRaycast>();
        interactionVolumen.GetComponent<InteractionVolumen>();
        
    }

    /// <summary>
    /// UI dedicada a la representación de interacción.
    /// </summary>
    public GameObject UI;
    public Text text;

    

    private void OnEnable()
    {
        text = UI.GetComponent<Text>();
    }

    /// <summary>
    /// Se subscribe como posible activador.
    /// </summary>
    /// <param name="interactable">Un objeto del tipo Interactable a registrar.</param>
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

    /// <summary>
    /// Acciona posible activador.
    /// </summary>
    private void DetectActivator()
    {
        if (InputManager.Instance.InteractPressed)
        {
            currentInteractable?.Interact();
        }
    }



}

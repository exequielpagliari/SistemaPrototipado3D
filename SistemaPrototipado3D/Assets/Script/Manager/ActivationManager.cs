using UnityEngine;

/// <summary>
/// Clase dedicada a la manipualación de IActivators en el Actor.
/// </summary>
public class ActivationManager : MonoBehaviour ,IActivatorReceiver
{
    private IActivator currentActivator;
    /// <summary>
    /// UI dedicada a la representación de interacción.
    /// </summary>
    public GameObject UI;

    /// <summary>
    /// Se subscribe como posible activador.
    /// </summary>
    /// <param name="activator">Un objeto del tipo IActivator a registrar.</param>

    public void RegisterActivator(IActivator activator)
    {
        currentActivator = activator;
        UI.SetActive(true);

    }

    /// <summary>
    /// Se desubscribe como posible activador.
    /// </summary>
    /// <param name="activator">Un objeto del tipo IActivator a desregistrar.</param>
    public void UnregisterActivator(IActivator activator)
    {
        if (currentActivator == activator)
        {    
            currentActivator = null;
            UI.SetActive(false);
        }
    }

    private void Update()
    {

            if (InputManager.Instance.InteractPressed)
            {
              currentActivator?.Activate();
            }      
    }
}

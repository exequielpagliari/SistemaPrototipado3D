
using UnityEngine;

/// <summary>
/// Clase dedicada a la emisión de un evento cuando una interfaz IActivator ejecuta Activate.
/// </summary>
public class VolumenAutoInteractable : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Enum dedicado a la selección de canal para evento.
    /// </summary>
    public EventChannelID channelToActivate;
    
    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool log;

    /// <summary>
    /// String que se representará en la UI.
    /// </summary>
    public string actionString;
    /// <summary>
    /// Get de String para IInteractable.
    /// </summary>
    public string GetInteractionPrompt() => actionString;

    /// <summary>
    /// Método único para realizar una activación.
    /// </summary>
    public void Interact()
    {
        if(log)
            Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
        EventChannelManager.RaiseEvent(channelToActivate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IActor>(out var receiver))
        {
            Interact();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IActor>(out var receiver))
        {
            Interact();
        }
    }

}

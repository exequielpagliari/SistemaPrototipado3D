using UnityEngine;

/// <summary>
/// Clase dedicada a la emisión de un evento cuando una interfaz IActivator ejecuta Activate.
/// </summary>
public class VolumenActionActivator : MonoBehaviour, IActivator
{
    /// <summary>
    /// Enum dedicado a la selección de canal para evento.
    /// </summary>
    public EventChannelID channelToActivate;
    private ActivationManager activationManager;
    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool log;
    /// <summary>
    /// Método único para realizar una activación.
    /// </summary>
    public void Activate()
    {
        if(log)
            Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
        EventChannelManager.RaiseEvent(channelToActivate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IActivatorReceiver>(out var receiver))
        {
            receiver.RegisterActivator(this);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IActivatorReceiver>(out var receiver))
        {
            receiver.UnregisterActivator(this);
        }
    }

}

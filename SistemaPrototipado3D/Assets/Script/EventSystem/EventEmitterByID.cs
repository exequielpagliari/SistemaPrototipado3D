using UnityEngine;
/// <summary>
/// Clase dedicada a la emici�n de evento en un canal espec�fico.
/// </summary>
public class EventEmitterByID : MonoBehaviour
{
    /// <summary>
    /// Enum dedicado a la selecci�n de canal para evento.
    /// </summary>
    [DrawEventConnection("channel")]
    public EventChannelID channel;

    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool Log;

    /// <summary>
    /// M�todo dedicado a la emisi�n del evento.
    /// </summary>
    public void Emit()
    {
        if(Log)
            Debug.LogWarning("Emitio desde EventEmitter");
        EventChannelManager.RaiseEvent(channel);
    }
}

using UnityEngine;
/// <summary>
/// Clase dedicada a la emición de evento en un canal específico.
/// </summary>
public class EventEmitterByID : MonoBehaviour
{
    /// <summary>
    /// Enum dedicado a la selección de canal para evento.
    /// </summary>
    [DrawEventConnection("channel")]
    public EventChannelID channel;

    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool Log;

    /// <summary>
    /// Método dedicado a la emisión del evento.
    /// </summary>
    public void Emit()
    {
        if(Log)
            Debug.LogWarning("Emitio desde EventEmitter");
        EventChannelManager.RaiseEvent(channel);
    }
}

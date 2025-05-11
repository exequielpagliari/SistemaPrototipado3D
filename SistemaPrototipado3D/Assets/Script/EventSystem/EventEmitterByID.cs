using UnityEngine;

public class EventEmitterByID : MonoBehaviour
{
    [SerializeField] private EventChannelID channel;

    public void Emit()
    {
        Debug.LogWarning("Emitio desde EventEmitter");
        EventChannelManager.RaiseEvent(channel);
    }
}

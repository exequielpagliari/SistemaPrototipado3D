using UnityEngine;

public class EventReceiverByID : MonoBehaviour
{
    [SerializeField] private EventChannelID channel;
    [SerializeField] private EnvironmentAction action;

    private void OnEnable()
    {
        Debug.LogWarning("Registra");
        EventChannelManager.Register(channel, OnEventReceived);
    }

    private void OnDisable()
    {
        EventChannelManager.Unregister(channel, OnEventReceived);
    }

    private void OnEventReceived()
    {
        Debug.Log("Recibe");
        if (action != null)
            action.Execute();
    }
}

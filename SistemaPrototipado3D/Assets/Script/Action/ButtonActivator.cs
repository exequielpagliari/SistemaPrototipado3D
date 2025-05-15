using System;
using UnityEngine;

public class ButtonActivator : MonoBehaviour, IActivator
{
    [SerializeField] private EventChannelID channelToActivate;
    private ActivationManager activationManager;
    public void Activate()
    {
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

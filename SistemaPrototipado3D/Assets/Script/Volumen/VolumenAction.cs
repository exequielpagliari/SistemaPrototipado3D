using System;
using UnityEngine;

public class VolumenAction : MonoBehaviour, IActivator
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
            Activate();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IActivatorReceiver>(out var receiver))
        {
            Activate();
        }
    }

}

using System;
using UnityEngine;

public class VolumenKill : MonoBehaviour
{
    [SerializeField] private EventChannelID channelToActivate;
    private ActivationManager activationManager;

    public void Kill(IActor actor)
    {
        Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
        EventChannelManager.RaiseEvent(channelToActivate);
        actor.Dead();
    }

    public bool CanActivate(IActivator activator)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IActor>(out var receiver))
        {
            Kill(receiver);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IActor>(out var receiver))
        {
            Kill(receiver);
        }
    }

}

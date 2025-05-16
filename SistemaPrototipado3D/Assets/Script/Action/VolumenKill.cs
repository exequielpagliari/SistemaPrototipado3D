using System;
using UnityEngine;

public class VolumenKill : MonoBehaviour
{
    [SerializeField] private EventChannelID channelToActivate;


    public void Kill(IActor actor)
    {
        Debug.Log($"[VolumenKill] Activando canal {channelToActivate}");
        EventChannelManager.RaiseEvent(channelToActivate);
        actor.Dead();
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

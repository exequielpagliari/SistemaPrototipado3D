using UnityEngine;

public class ButtonActivator : MonoBehaviour, IActivator
{
    [SerializeField] private EventChannelID channelToActivate;

    public void Activate()
    {
        Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
        EventChannelManager.RaiseEvent(channelToActivate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Activate();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class EventReceiverByID : MonoBehaviour
{
    [SerializeField] private EventChannelID channel;
    [SerializeField] private MonoBehaviour[] actions; // Todos deben implementar IAction

    private List<IAction> _actions = new();

    private void Awake()
    {
        foreach (var action in actions)
        {
            if (action is IAction ia)
                _actions.Add(ia);
        }
    }

    private void OnEnable()
    {
        Debug.LogWarning("Registra");

        EventChannelManager.Register(channel, TriggerActions);
    }

    private void OnDisable()
    {

        EventChannelManager.Unregister(channel, TriggerActions);
    }



    private void TriggerActions()
    {
        foreach (var action in _actions)
            action.Execute();
    }
}

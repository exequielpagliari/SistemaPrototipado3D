using System.Collections.Generic;
using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a la recepción de eventos en un canal específico.
/// </summary>
public class EventReceiverByID : MonoBehaviour
{
    /// @private
    /// <summary>
    /// Enum para seleccionar canal para recibir evento.
    /// </summary>
    [DrawEventConnection("channel")]
    public EventChannelID channel;
    /// @private
    /// <summary>
    /// Lista de Acciones a realizarse por el evento.
    /// </summary>
    public MonoBehaviour[] actions;
    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool Log;

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
        if(Log)
        Debug.LogWarning("Registra");
        EventChannelManager.Register(channel, TriggerActions);
    }

    private void OnDisable()
    {
        EventChannelManager.Unregister(channel, TriggerActions);
    }



    private void TriggerActions()
    {
        if (Log)
            Debug.Log($"Evento recibido por canal +{channel.ToString()}");
        foreach (var action in _actions)
            action.Execute();
    }
}

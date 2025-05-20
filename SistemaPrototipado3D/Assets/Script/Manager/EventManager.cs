using System;
using System.Collections.Generic;

/// <summary>
/// Enum dedicado a la identificación de canales para los eventos.
/// </summary>
public enum EventChannelID
{
    Canal_1,
    Canal_2,
    Canal_3,
    Canal_4,
    Canal_5,
    Canal_6,
    Canal_7,
    Canal_8,
    Canal_9

}
/// <summary>
/// Clase dedicada a la transferencia de eventos.
/// </summary>
public static class EventChannelManager
{
    private static Dictionary<EventChannelID, Action> channelEvents = new();

    /// <summary>
    /// Metodo de envío de Evento.
    /// </summary>
    /// <param name="activator">Un objeto del tipo IActivator a desregistrar.</param>
    public static void RaiseEvent(EventChannelID channel)
    {
        if (channelEvents.TryGetValue(channel, out var evt))
            evt?.Invoke();
    }

    /// <summary>
    /// Metodo de Registro de Evento.
    /// </summary>
    /// <param name="channel">Canal a donde registrar el evento.</param>
    /// <param name="listener">Action que espera el evento para accionar.</param>
    public static void Register(EventChannelID channel, Action listener)
    {
        if (!channelEvents.ContainsKey(channel))
            channelEvents[channel] = null;

        channelEvents[channel] += listener;
    }

    /// <summary>
    /// Metodo de desregistrar de Evento.
    /// </summary>
    /// <param name="channel">Canal a donde desregistrar el evento.</param>
    /// <param name="listener">Action que se desregistra del evento.</param>
    public static void Unregister(EventChannelID channel, Action listener)
    {
        if (channelEvents.ContainsKey(channel))
            channelEvents[channel] -= listener;
    }
}

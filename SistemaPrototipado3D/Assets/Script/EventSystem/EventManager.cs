using System;
using System.Collections.Generic;


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
public static class EventChannelManager
{
    private static Dictionary<EventChannelID, Action> channelEvents = new();

    public static void RaiseEvent(EventChannelID channel)
    {
        if (channelEvents.TryGetValue(channel, out var evt))
            evt?.Invoke();
    }

    public static void Register(EventChannelID channel, Action listener)
    {
        if (!channelEvents.ContainsKey(channel))
            channelEvents[channel] = null;

        channelEvents[channel] += listener;
    }

    public static void Unregister(EventChannelID channel, Action listener)
    {
        if (channelEvents.ContainsKey(channel))
            channelEvents[channel] -= listener;
    }
}

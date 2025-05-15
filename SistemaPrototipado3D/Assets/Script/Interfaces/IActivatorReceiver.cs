using UnityEngine;

public interface IActivatorReceiver
    {
        void RegisterActivator(IActivator activator);
        void UnregisterActivator(IActivator activator);
    }


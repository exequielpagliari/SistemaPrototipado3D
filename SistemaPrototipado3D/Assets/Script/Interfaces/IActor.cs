using UnityEngine;

public interface IActor
{
    string ActorID { get; }
    Transform Transform { get; }
    bool CanActivate(IActivator activator);
    void Dead();
}
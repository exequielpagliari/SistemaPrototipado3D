using UnityEngine;

public class PlayerActor : MonoBehaviour, IActor
{
    [SerializeField] private string actorID = "Player";

    public string ActorID => actorID;
    public Transform Transform => transform;

    public bool CanActivate(IActivator activator)
    {
        // Acá podés poner condiciones (tiene item, no está bloqueado, etc)
        return true;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}

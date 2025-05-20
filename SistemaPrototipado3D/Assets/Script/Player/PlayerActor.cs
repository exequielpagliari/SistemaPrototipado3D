using UnityEngine;
/// <summary>
/// Implementación IActor para Player.
/// </summary>
public class PlayerActor : MonoBehaviour, IActor
{
    /// <summary>
    /// String representativo del Actor privado.
    /// </summary>
    [SerializeField] private string actorID = "Player";
    /// <summary>
    /// String representativo del Actor.
    /// </summary>
    public string ActorID => actorID;
    /// <summary>
    /// Transform del Actor.
    /// </summary>
    public Transform Transform => transform;

    /// <summary>
    /// Si puede activar determinado Activador.
    /// </summary>
    public bool CanActivate(IActivator activator)
    {
        // Acá podés poner condiciones (tiene item, no está bloqueado, etc)
        return true;
    }
    /// <summary>
    /// Método de muerte del Actor.
    /// </summary>
    public void Dead()
    {
        Destroy(gameObject);
    }
}

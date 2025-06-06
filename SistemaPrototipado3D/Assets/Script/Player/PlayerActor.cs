using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Implementaci�n IActor para Player.
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
        // Ac� pod�s poner condiciones (tiene item, no est� bloqueado, etc)
        return true;
    }
    /// <summary>
    /// M�todo de muerte del Actor.
    /// </summary>
    public void Dead()
    {
        Destroy(gameObject);
    }
}

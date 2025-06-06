using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a la Construcci�n del PlayerFPS.
/// </summary>
public class PlayerCCFPSBuillder : MonoBehaviour, IAction
{
    /// <summary>
    /// GameObject de PlayerFPS.
    /// </summary>
    public GameObject playerFPS;
    /// <summary>
    /// Locaci�n de creacion del Player.
    /// </summary>
    public GameObject playerBuildLocation;
    /// <summary>
    /// Referencia a ActorManager.
    /// </summary>
    private ActorManager am;

    private void OnEnable()
    {
            am = FindAnyObjectByType<ActorManager>();
    }

    /// <summary>
    /// Creaci�n de PlayerFPS.
    /// </summary>
    public void Execute()
    {
        am.Build(playerFPS, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
    }

}

using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a la Construcción del PlayerFPS.
/// </summary>
public class PlayerCCFPSBuillder : MonoBehaviour, IAction
{
    /// <summary>
    /// GameObject de PlayerFPS.
    /// </summary>
    public GameObject playerFPS;
    /// <summary>
    /// Locación de creacion del Player.
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
    /// Creación de PlayerFPS.
    /// </summary>
    public void Execute()
    {
        am.Build(playerFPS, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
    }

}

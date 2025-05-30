using Unity.Cinemachine;
using UnityEngine;
using Prototipe.Core.Interfaces;

/// <summary>
/// Clase dedicada a la Construcción del Player.
/// </summary>
public class PlayerCCBuillder : MonoBehaviour, IAction
{
    /// <summary>
    /// GameObject de Player.
    /// </summary>
    public GameObject playerCC;
    /// <summary>
    /// Locación de creacion del Player.
    /// </summary>
    public GameObject playerBuildLocation;
    /// <summary>
    /// Referencia a Cinemachine.
    /// </summary>
    public CinemachineCamera cinCam;
    private ActorManager am;

    private void OnEnable()
    {
            am = FindAnyObjectByType<ActorManager>();
    }

    /// <summary>
    /// Creación de Player y entrega a CineMachine la referencia.
    /// </summary>
    public void Execute()
    {
        am.Build(playerCC, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
        cinCam.Target.TrackingTarget = FindAnyObjectByType<PlayerActor>().gameObject.transform;
    }

}

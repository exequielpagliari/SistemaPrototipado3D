using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Clase dedicada a la Construcci�n del Player.
/// </summary>
public class PlayerBuillder : MonoBehaviour, IAction
{
    /// <summary>
    /// GameObject de Player.
    /// </summary>
    public GameObject playerGO;
    /// <summary>
    /// Locaci�n de creacion del Player.
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
    /// Creaci�n de Player y entrega a CineMachine la referencia.
    /// </summary>
    public void Execute()
    {
        am.Build(playerGO, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
        cinCam.Target.TrackingTarget = FindAnyObjectByType<PlayerActor>().gameObject.transform;
    }

}

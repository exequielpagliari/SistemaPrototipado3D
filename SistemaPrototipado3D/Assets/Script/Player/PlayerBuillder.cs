using Unity.Cinemachine;
using UnityEngine;

public class PlayerBuillder : MonoBehaviour, IAction
{
    public GameObject playerGO;
    public GameObject playerBuildLocation;
    public CinemachineCamera cinCam;
    private ActorManager am;

    private void OnEnable()
    {
            am = FindAnyObjectByType<ActorManager>();
    }

    public void Execute()
    {
        am.Build(playerGO, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
        cinCam.Target.TrackingTarget = FindAnyObjectByType<PlayerActor>().gameObject.transform;
    }

}

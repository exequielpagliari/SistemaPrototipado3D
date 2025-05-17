using UnityEngine;

public class PlayerBuillder : MonoBehaviour, IAction
{
    public GameObject playerGO;
    public GameObject playerBuildLocation;
    private ActorManager am;

    private void OnEnable()
    {
            am = FindAnyObjectByType<ActorManager>();
    }

    public void Execute()
    {
        am.Build(playerGO, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
    }

}

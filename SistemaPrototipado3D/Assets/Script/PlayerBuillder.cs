using UnityEngine;

public class PlayerBuillder : MonoBehaviour, IAction
{
    public GameObject playerGO;
    public GameObject playerBuildLocation;
    private EntityManager em;

    private void OnEnable()
    {
            em = FindAnyObjectByType<EntityManager>();
    }

    public void Execute()
    {
        em.Build(playerGO, playerBuildLocation.transform, playerBuildLocation.transform.rotation);
    }

}

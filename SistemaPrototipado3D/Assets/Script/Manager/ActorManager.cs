using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public void Build(GameObject gameObject, Transform transform, Quaternion rotation)
    {
        GameObject go = Instantiate(gameObject, transform.position, rotation, null);

    }
}

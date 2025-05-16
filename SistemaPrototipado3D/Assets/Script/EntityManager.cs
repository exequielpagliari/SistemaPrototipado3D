using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public void Build(GameObject gameObject, Transform transform, Quaternion rotation)
    {
        GameObject go = Instantiate(gameObject, transform.position, rotation, null);

    }
}

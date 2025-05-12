using UnityEngine;

public class MoveAction : MonoBehaviour, IAction
{
    [SerializeField] private Vector3 offset;

    public void Execute()
    {
        transform.position += offset;
    }
}

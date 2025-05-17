using UnityEngine;

public class MoveAction : MonoBehaviour, IAction
{
    [SerializeField] private Transform m_MoveTransform;
    public bool loop;
    private bool action;

    public void Execute()
    {
        if(!action)
        {        
            if (m_MoveTransform == null) return;

            transform.position = m_MoveTransform.position;
            action = !action;
        }
        if (loop)
            action = false;
    }
}

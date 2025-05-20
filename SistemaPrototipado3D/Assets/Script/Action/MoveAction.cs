using UnityEngine;


/// <summary>
/// Clase dedicada a generar un desplazamiento por medio de la Interfaz IAction.
/// </summary>
public class MoveAction : MonoBehaviour, IAction
{
    [SerializeField] private Transform m_MoveTransform;
    /// <summary>
    /// Booleano que habilita repetir la acción cada vez que el método Execute utilizado.
    /// </summary>
    public bool loop;
    private bool action;


    /// <summary>
    /// Método para modificar la posición en función de un Transform externo.
    /// </summary>
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

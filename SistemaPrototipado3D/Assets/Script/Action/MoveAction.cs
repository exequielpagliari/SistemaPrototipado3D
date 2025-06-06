using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase dedicada a generar un desplazamiento por medio de la Interfaz IAction.
    /// </summary>
    [System.Serializable]
    public class MoveAction : MonoBehaviour, IAction
    {
        [SerializeField] private Transform m_MoveTransform;
        /// <summary>
        /// Booleano que habilita repetir la acci�n cada vez que el m�todo Execute utilizado.
        /// </summary>
        public bool loop;
        private bool action;


        /// <summary>
        /// M�todo para modificar la posici�n en funci�n de un Transform externo.
        /// </summary>
        public void Execute()
        {
            if (!action)
            {
                if (m_MoveTransform == null) return;

                transform.position = m_MoveTransform.position;
                action = !action;
            }
            if (loop)
                action = false;
        }
    }
}
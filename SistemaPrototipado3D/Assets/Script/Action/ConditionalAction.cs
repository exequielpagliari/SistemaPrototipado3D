using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase dedicada a manejar condiciones para realizar acciones.
    /// </summary>
    public class ConditionalAction : MonoBehaviour, IAction
    {
        /// <summary>
        /// Condición utilizada para la acción.
        /// </summary>
        public MonoBehaviour conditionComponent;
        /// <summary>
        /// Acción a realizar.
        /// </summary>
        public MonoBehaviour actionComponent;

        public bool log = false;



        private ICondition condition => conditionComponent as ICondition;
        private IAction action => actionComponent as IAction;
        /// <summary>
        /// Ejecución de la acción.
        /// </summary>
        public void Execute()
        {
            if (log)
                Debug.LogWarning("Se ejecutó");
            if (condition != null && condition.IsMet())
            {
                if (log)
                    Debug.LogWarning("Se ejecutó la condición");
                action?.Execute();
            }
        }
    }
}
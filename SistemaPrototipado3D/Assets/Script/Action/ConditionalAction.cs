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
        /// Condici�n utilizada para la acci�n.
        /// </summary>
        public MonoBehaviour conditionComponent;
        /// <summary>
        /// Acci�n a realizar.
        /// </summary>
        public MonoBehaviour actionComponent;

        public bool log = false;



        private ICondition condition => conditionComponent as ICondition;
        private IAction action => actionComponent as IAction;
        /// <summary>
        /// Ejecuci�n de la acci�n.
        /// </summary>
        public void Execute()
        {
            if (log)
                Debug.LogWarning("Se ejecut�");
            if (condition != null && condition.IsMet())
            {
                if (log)
                    Debug.LogWarning("Se ejecut� la condici�n");
                action?.Execute();
            }
        }
    }
}
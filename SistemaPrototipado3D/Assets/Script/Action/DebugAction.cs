using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase que se dedica a la generaci�n de un Warning por medio de IAction
    /// </summary>
    public class DebugAction : MonoBehaviour, IAction
    {
        /// <summary>
        /// String que se va a emitir al realizarse la acci�n.
        /// </summary>
        public string debugString;
        /// <summary>
        /// Booleano que selecciona entre un log y un warning.
        /// </summary>
        public bool Warning;
        /// <summary>
        /// M�todo para etimir un log.
        /// </summary>
        public void Execute()
        {
            if (Warning)
                Debug.LogWarning(debugString);
            else
                Debug.Log(debugString);
        }


    }
}
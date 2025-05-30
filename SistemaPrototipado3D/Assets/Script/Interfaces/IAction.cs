using UnityEngine;

namespace Prototipe.Core.Interfaces
{


    /// <summary>
    /// Interfaz dedicada a la interacción de acciones.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Método único para realizar una acción.
        /// </summary>
        void Execute();
    }

}
using UnityEngine;

namespace Prototipe.Core.Interfaces
{
    /// <summary>
    /// Interfaz dedicada a la interacción con Actores.
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// String representativo del Actor.
        /// </summary>
        string ActorID { get; }
        /// <summary>
        /// Transform del Actor.
        /// </summary>
        Transform Transform { get; }
        /// <summary>
        /// Si puede activar determinado Activador.
        /// </summary>
        bool CanActivate(IActivator activator);
        /// <summary>
        /// Método de muerte del Actor.
        /// </summary>
        void Dead();
    }

}
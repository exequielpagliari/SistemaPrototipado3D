
namespace Prototipe.Core.Interfaces
{
    /// <summary>
    /// Interfaz dedicada a la subscripción de activadores.
    /// </summary>
    public interface IActivatorReceiver
    {
        /// <summary>
        /// Se subscribe como posible activador.
        /// </summary>
        void RegisterActivator(IActivator activator);
        /// <summary>
        /// Se desubscribe como posible activador.
        /// </summary>
        void UnregisterActivator(IActivator activator);
    }

}
namespace Prototipe.Core.Interfaces
{
    /// <summary>
    /// Interfaz dedicada a la interacci�n.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// M�todo �nico para realizar una acci�n.
        /// </summary>
        void Interact();
        /// <summary>
        /// M�todo obtener String para la UI de Interacci�n.
        /// </summary>
        string GetInteractionPrompt();
    }

}
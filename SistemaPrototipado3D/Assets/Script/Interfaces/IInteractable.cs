

/// <summary>
/// Interfaz dedicada a la interacción.
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Método único para realizar una acción.
    /// </summary>
    void Interact();
    /// <summary>
    /// Método obtener String para la UI de Interacción.
    /// </summary>
    string GetInteractionPrompt();
}


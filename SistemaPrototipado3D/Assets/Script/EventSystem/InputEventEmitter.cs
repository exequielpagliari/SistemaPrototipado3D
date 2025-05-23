using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Clase dedicada a la emisi�n de eventos en un canal espec�fico, desde un InputAction espec�fico.
/// </summary>
public class InputEventEmitter : MonoBehaviour
{
    /// <summary>
    /// Canal de emisi�n de evento.
    /// </summary>
    public EventChannelID channel;
    /// <summary>
    /// InputAction a utilizar para emitir el evento.
    /// </summary>
    public InputActionReference inputAction;
    /// <summary>
    /// Bool activa el LogWarning para test de funcionamiento.
    /// </summary>
    public bool Log;

    private void OnEnable()
    {
        if (inputAction != null)
            inputAction.action.performed += OnPerformed;
    }

    private void OnDisable()
    {
        if (inputAction != null)
            inputAction.action.performed -= OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        if(Log)
        Debug.LogWarning("InputFunciono");
        EventChannelManager.RaiseEvent(channel);
    }
}


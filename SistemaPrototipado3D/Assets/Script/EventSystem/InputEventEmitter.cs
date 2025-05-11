using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventEmitter : MonoBehaviour
{
    [SerializeField] private EventChannelID channel;
    [SerializeField] private InputActionReference inputAction;

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
        Debug.LogWarning("InputFunciono");
        EventChannelManager.RaiseEvent(channel);
    }
}


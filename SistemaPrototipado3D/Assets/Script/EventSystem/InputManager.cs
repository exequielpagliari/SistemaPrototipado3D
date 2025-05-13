using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public InputSystem_Actions inputActions;

    public Vector2 MoveInput { get; private set; }
    public bool InteractPressed { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();

        // Suscribimos las acciones
        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

        inputActions.Player.Interact.started += _ => InteractPressed = true;
    }

    private void LateUpdate()
    {
        InteractPressed = false;
    }

    public void EnableGameplayInput() => inputActions.Player.Enable();
    public void DisableGameplayInput() => inputActions.Player.Disable();
}

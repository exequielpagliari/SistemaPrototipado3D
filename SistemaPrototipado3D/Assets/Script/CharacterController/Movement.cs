using UnityEngine;
using Prototipe.Core.Actions;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;



    private CharacterController controller;
    private Vector3 velocity;
    public float velocityMagnitude;
 




    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private Vector3 dashDirection;

    private RaycastGround raycastGround;


    /// <summary>
    /// Referencia de Plataforma para desplazar al jugador al momento de estar sobre una.
    /// </summary>
    [HideInInspector]
    public MoveActionPlataformCorrutine currentPlatform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        raycastGround = GetComponent<RaycastGround>();
    }

    void Update()
    {
        if (dashCooldownTimer > 0f)
            dashCooldownTimer -= Time.deltaTime;

        Vector3 input = new Vector3(InputManager.Instance.MoveInput.x, 0, InputManager.Instance.MoveInput.y);

            MoveOnGround(input);

        if (InputManager.Instance.SprintPressed && dashCooldownTimer <= 0f && !isDashing)
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashCooldownTimer = dashCooldown;

            Vector3 inputDir = new Vector3(InputManager.Instance.MoveInput.x, 0, InputManager.Instance.MoveInput.y);
            dashDirection = inputDir.magnitude > 0.1f ? inputDir.normalized : transform.forward;
            dashDirection = transform.TransformDirection(dashDirection);
        }

        if (isDashing)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }

            return;
        }
    }

    void MoveOnGround(Vector3 input)
    {
        

        Vector3 move = transform.right * input.x + transform.forward * input.z;
        controller.Move(move * speed * Time.deltaTime);
        velocityMagnitude = move.magnitude;


        if (raycastGround.IsGrounded() && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (InputManager.Instance.JumpPressed && raycastGround.IsGrounded())
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        bool isMoving = move.magnitude > 0.1f && raycastGround.IsGrounded();



    }



    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var platform = hit.collider.GetComponentInParent<MoveActionPlataformCorrutine>();
        if (platform != null)
            currentPlatform = platform;
        else
            currentPlatform = null;
    }

    void LateUpdate()
    {
        if (currentPlatform != null)
            controller.Move(currentPlatform.MovementDelta);
    }
}

using UnityEngine;
using Prototipe.Core.Actions;

/// <summary>
/// Controla el movimiento del Player utilizando un CharacterController.
/// </summary>


/// <remarks>
/// Requiere un CharacterController, RaycastGround e InputManager.
/// </remarks>
[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(RaycastGround))]
public class MovementCC : MonoBehaviour
{
    private CharacterController cc;
    /// <summary>
    /// Velocidad base del movimiento del jugador.
    /// </summary>
    public float speed = 1f;
    private float gravityValue = -9.81f;
    private float jumpHeight = 1.0f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private RaycastGround raycastGround;


    /// <summary>
    /// Referencia de Plataforma para desplazar al jugador al momento de estar sobre una.
    /// </summary>
    [HideInInspector]
    public MoveActionPlataformCorrutine currentPlatform;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        raycastGround = GetComponent<RaycastGround>();
    }


    void Update()
    {

        groundedPlayer = cc.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 horizontalVelocity = cc.velocity;
        horizontalVelocity = new Vector3(-InputManager.Instance.MoveInput.y, 0, InputManager.Instance.MoveInput.x);
        

        if (InputManager.Instance.JumpPressed && raycastGround.IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;


        Vector3 finalMove = (horizontalVelocity * speed) + (playerVelocity.y * Vector3.up);
        cc.Move(finalMove * Time.deltaTime);

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
            cc.Move(currentPlatform.MovementDelta);
    }
}

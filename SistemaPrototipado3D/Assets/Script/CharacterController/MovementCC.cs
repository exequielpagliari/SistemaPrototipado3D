using UnityEngine;



public class MovementCC : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 1f;
    private float gravityValue = -9.81f;
    private float jumpHeight = 1.0f;
    public bool groundedPlayer;
    private Vector3 playerVelocity;
    private RaycastGround raycastGround;


    public MoveActionPlataformCorrutine currentPlatform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        raycastGround = GetComponent<RaycastGround>();
    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = cc.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 horizontalVelocity = cc.velocity;
        horizontalVelocity = new Vector3(-InputManager.Instance.MoveInput.y, 0, InputManager.Instance.MoveInput.x);
        
        // Jump
        if (InputManager.Instance.JumpPressed && raycastGround.IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
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

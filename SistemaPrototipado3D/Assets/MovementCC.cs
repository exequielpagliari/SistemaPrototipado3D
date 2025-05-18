using UnityEngine;



public class MovementCC : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 1f;
    private float gravityValue = -9.81f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
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
        horizontalVelocity = new Vector3(0,0, InputManager.Instance.MoveInput.x);

        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (horizontalVelocity * speed) + (playerVelocity.y * Vector3.up);
        cc.Move(finalMove * Time.deltaTime);

    }
}

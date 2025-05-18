using UnityEngine;

public class RaycastGround : MonoBehaviour
{
    public LayerMask groundMask;
    public float groundCheckDistance = 0.1f;

    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    public bool IsGrounded()
    {
        // Punto abajo del collider, centrado en XZ, con un pequeño margen hacia arriba para evitar atravesar
        Vector3 origin = new Vector3(transform.position.x, col.bounds.min.y + 0.01f, transform.position.z);

        return Physics.Raycast(origin, Vector3.down, groundCheckDistance, groundMask);
    }
}

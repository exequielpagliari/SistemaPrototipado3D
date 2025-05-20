using UnityEngine;

/// <summary>
/// Clase dedicada a disparar un Raycast hacia abajo para detectar Ground.
/// </summary>
public class RaycastGround : MonoBehaviour
{
    /// <summary>
    /// Máscara para detectar en el Raycast.
    /// </summary>
    public LayerMask groundMask;
    /// <summary>
    /// Distancia de detección del Raycast.
    /// </summary>
    public float groundCheckDistance = 0.1f;

    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    /// <summary>
    /// Método que llama a la deteccion del Raycast.
    /// </summary>
    public bool IsGrounded()
    {
        Vector3 origin = new Vector3(transform.position.x, col.bounds.min.y + 0.01f, transform.position.z);

        return Physics.Raycast(origin, Vector3.down, groundCheckDistance, groundMask);
    }
}

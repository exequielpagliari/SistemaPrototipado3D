using UnityEngine;

/// <summary>
/// Calse dedicada la rotación de la camara FPS.
/// </summary>
public class Look : MonoBehaviour
{
    [Header("Mouse Look")]
    /// <summary>
    /// Float de sensibilidad de rotación.
    /// </summary>
    public float mouseSensitivity = 100f;
    /// <summary>
    /// Transform de la cámara.
    /// </summary>
    public Transform cameraTransform;

    /// <summary>
    /// Float que almacena la rotación x para cálculo.
    /// </summary>
    private float xRotation = 0f;

    void Update()
    {

        float mouseX = InputManager.Instance.LookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = InputManager.Instance.LookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}

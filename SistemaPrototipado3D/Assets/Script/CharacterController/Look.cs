using UnityEngine;

/// <summary>
/// Calse dedicada la rotaci�n de la camara FPS.
/// </summary>
public class Look : MonoBehaviour
{
    [Header("Mouse Look")]
    /// <summary>
    /// Float de sensibilidad de rotaci�n.
    /// </summary>
    public float mouseSensitivity = 100f;
    /// <summary>
    /// Transform de la c�mara.
    /// </summary>
    public Transform cameraTransform;

    /// <summary>
    /// Float que almacena la rotaci�n x para c�lculo.
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

using UnityEngine;
using System.Collections;
/// <summary>
/// Clase dedicada a la rotación, ejecutable desde la interfaz IAction.
/// </summary>
public class RotateAction : MonoBehaviour, IAction
{
    /// <summary>
    /// Enum para elegir el tipo de rotación. Se puede elejir por rotación por eje, o customizar la rotación.
    /// </summary>
    public enum Axis { X, Y, Z, Custom }

    [Header("Configuración")]
    /// <summary>
    /// Referencia del Transform a afectar.
    /// </summary>
    public Transform target;
    /// <summary>
    /// Selección de tipo de rotación a generar.
    /// </summary>
    public Axis rotationAxis = Axis.Y;
    /// <summary>
    /// Vector3 del valor de rotación, según el tipo de rotación escogido.
    /// </summary>
    public Vector3 customAxis = Vector3.zero;

    /// <summary>
    /// Float de cantida ángulo a rotar.
    /// </summary>
    public float angle = 90f;
    /// <summary>
    /// Float de la duración de la rotación.
    /// </summary>
    public float duration = 1.5f;

    private bool isRotating = false;
    /// <summary>
    /// Bool para que se comporte como puerta.
    /// </summary>
    public bool isDoor = false;
    private bool isOpen = false;

    /// <summary>
    /// Método que ejecuta la rotación.
    /// </summary>
    public void Execute()
    {

        if (!isRotating)
        {
            StartCoroutine(RotateOverTime());            
        }
            
    }

    private IEnumerator RotateOverTime()
    {
        
        isRotating = true;

        Quaternion initialRotation = target.rotation;
        Vector3 axis = GetAxis();
        Quaternion finalRotation = initialRotation * Quaternion.AngleAxis(angle, axis);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            target.rotation = Quaternion.Slerp(initialRotation, finalRotation, t);
            yield return null;
        }

        target.rotation = finalRotation;
        isOpen = !isOpen;
        isRotating = false;
        if(isDoor)
        angle = -angle;
        StopCoroutine(RotateOverTime());
    }

    private Vector3 GetAxis()
    {
        return rotationAxis switch
        {
            Axis.X => Vector3.right,
            Axis.Y => Vector3.up,
            Axis.Z => Vector3.forward,
            Axis.Custom => customAxis.normalized,
            _ => Vector3.up
        };
    }
}

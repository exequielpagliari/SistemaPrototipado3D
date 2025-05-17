using UnityEngine;
using System.Collections;

public class RotateAction : MonoBehaviour, IAction
{
    public enum Axis { X, Y, Z, Custom }

    [Header("Configuración")]
    public Transform target;
    public Axis rotationAxis = Axis.Y;
    public Vector3 customAxis = Vector3.zero;

    public float angle = 90f;
    public float duration = 1.5f;

    private bool isRotating = false;
    public bool isDoor = false;
    private bool isOpen = false;

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

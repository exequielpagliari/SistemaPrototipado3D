using UnityEngine;
using System.Collections;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase dedicada a la rotaci�n, ejecutable desde la interfaz IAction.
    /// </summary>
    [System.Serializable]
    public class RotateAction : MonoBehaviour, IAction
    {
        /// <summary>
        /// Enum para elegir el tipo de rotaci�n. Se puede elejir por rotaci�n por eje, o customizar la rotaci�n.
        /// </summary>
        public enum Axis { X, Y, Z, Custom }

        [Header("Configuraci�n")]
        /// <summary>
        /// Referencia del Transform a afectar.
        /// </summary>
        public Transform target;
        /// <summary>
        /// Selecci�n de tipo de rotaci�n a generar.
        /// </summary>
        public Axis rotationAxis = Axis.Y;
        /// <summary>
        /// Vector3 del valor de rotaci�n, seg�n el tipo de rotaci�n escogido.
        /// </summary>
        public Vector3 customAxis = Vector3.zero;

        /// <summary>
        /// Float de cantida �ngulo a rotar.
        /// </summary>
        public float angle = 90f;
        /// <summary>
        /// Float de la duraci�n de la rotaci�n.
        /// </summary>
        public float duration = 1.5f;

        private bool isRotating = false;
        /// <summary>
        /// Bool para que se comporte como puerta.
        /// </summary>
        public bool isDoor = false;
        private bool isOpen = false;

        /// <summary>
        /// M�todo que ejecuta la rotaci�n.
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
            if (isDoor)
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
}
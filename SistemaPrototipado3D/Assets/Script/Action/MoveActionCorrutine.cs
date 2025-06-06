using System.Collections;
using UnityEngine;
using Prototipe.Core.Interfaces;


namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase dedicada a generar un desplazamiento con Corrutina por medio de la Interfaz IAction.
    /// </summary>
    [System.Serializable]
    public class MoveActionCorrutine : MonoBehaviour, IAction
    {
        /// <summary>
        /// Booleano que determina si la acci�n se repite o no al ejecutarse el m�todo Execute().
        /// </summary>
        public bool loop;
        /// <summary>
        /// Booleano que determina si la acci�n se ejecuta o no.
        /// </summary>
        public bool action;
        private bool open = false;
        private bool isOpen = false;

        /// <summary>
        /// Float que determina el tiempo de duraci�n de la �cci�n.
        /// </summary>
        public float slideDuration;
        /// <summary>
        /// Float que determina el tiempo de retardo para que inicie la �cci�n.
        /// </summary>
        public float retard;

        /// <summary>
        /// Referencial del Transform que se desplazar� durante la Ejecuci�n.
        /// </summary>
        public Transform doorTransform;
        /// <summary>
        /// Referencial del Transform final de desplazamiento de la Ejecuci�n.
        /// </summary>
        public Transform openedPosition;
        /// <summary>
        /// Referencial del Transform inicial de desplazamiento de la Ejecuci�n.
        /// </summary>
        public Transform closedPosition;


        private Coroutine currentCoroutine;


        /// <summary>
        /// M�todo para modificar la posici�n en funci�n de un Transform externo.
        /// </summary>
        public void Execute()
        {
            if (!action)
                return;
            if(isOpen)
                return;
            if(!open)
            {
                open = true;
                OpenDoor(openedPosition.position);
            }
            else
            {
                open = false;
                CloseDoor();
            }
        }

        /// <summary>
        /// M�todo para modificar la posici�n en funci�n del Transform closedPosition.
        /// </summary>
        public void CloseDoor()
        {
        
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
        
            currentCoroutine = StartCoroutine(SlideTo(closedPosition.position));
        }


        /// <summary>
        /// M�todo para modificar la posici�n en funci�n de un Transform openedPosition.
        /// </summary>
        /// <param name="openPosition">Posici�n a la que llegar� en el desplazamiento m�ximo.</param>
        public void OpenDoor(Vector3 openPosition)
        {
        
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
        
            currentCoroutine = StartCoroutine(SlideTo(openPosition));
        }


        IEnumerator SlideTo(Vector3 targetPosition)
        {
            isOpen = true;
            Vector3 startPosition = doorTransform.position;
            float timeElapsed = 0f;

            while (timeElapsed < slideDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / slideDuration;
                doorTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
                yield return null;
            }

            doorTransform.position = targetPosition;
            isOpen = false;
        }
    }
}

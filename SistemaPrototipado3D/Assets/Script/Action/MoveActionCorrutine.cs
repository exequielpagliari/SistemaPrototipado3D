using System.Collections;
using UnityEngine;


/// <summary>
/// Clase dedicada a generar un desplazamiento con Corrutina por medio de la Interfaz IAction.
/// </summary>
public class MoveActionCorrutine : MonoBehaviour, IAction
{
    /// <summary>
    /// Booleano que determina si la acción se repite o no al ejecutarse el método Execute().
    /// </summary>
    public bool loop;
    /// <summary>
    /// Booleano que determina si la acción se ejecuta o no.
    /// </summary>
    public bool action;
    private bool open = false;
    private bool isOpen = false;

    /// <summary>
    /// Float que determina el tiempo de duración de la ácción.
    /// </summary>
    public float slideDuration;
    /// <summary>
    /// Float que determina el tiempo de retardo para que inicie la ácción.
    /// </summary>
    public float retard;

    /// <summary>
    /// Referencial del Transform que se desplazará durante la Ejecución.
    /// </summary>
    public Transform doorTransform;
    /// <summary>
    /// Referencial del Transform final de desplazamiento de la Ejecución.
    /// </summary>
    public Transform openedPosition;
    /// <summary>
    /// Referencial del Transform inicial de desplazamiento de la Ejecución.
    /// </summary>
    public Transform closedPosition;


    private Coroutine currentCoroutine;


    /// <summary>
    /// Método para modificar la posición en función de un Transform externo.
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
    /// Método para modificar la posición en función del Transform closedPosition.
    /// </summary>
    public void CloseDoor()
    {
        
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        
        currentCoroutine = StartCoroutine(SlideTo(closedPosition.position));
    }


    /// <summary>
    /// Método para modificar la posición en función de un Transform openedPosition.
    /// </summary>
    /// <param name="openPosition">Posición a la que llegará en el desplazamiento máximo.</param>
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

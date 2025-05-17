using System.Collections;
using TMPro;
using UnityEngine;

public class MoveActionCorrutine : MonoBehaviour, IAction
{

    public bool loop;
    public bool action;
    private bool open = false;
    private bool isOpen = false;

    public float slideDuration;
    public float retard;

    public Transform doorTransform;
    public Transform openedPosition;
    public Transform closedPosition;


    private Coroutine currentCoroutine;



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


    public void CloseDoor()
    {
        
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        
        currentCoroutine = StartCoroutine(SlideTo(closedPosition.position));
    }

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

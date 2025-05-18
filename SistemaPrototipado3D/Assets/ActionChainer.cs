using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChainer : MonoBehaviour, IAction
{
    public List<MonoBehaviour> actions = new();
    public bool runInSequence = false;
    public float delayBetweenActions = 0.5f;

    public void Execute()
    {
        if (runInSequence)
            StartCoroutine(RunSequence());
        else
            RunAllAtOnce();
    }

    private void RunAllAtOnce()
    {
        foreach (var action in actions)
        {
            if (action is IAction iaction)
                iaction.Execute();
        }
    }

    private IEnumerator RunSequence()
    {
        foreach (var action in actions)
        {
            if (action is IAction iaction)
                iaction.Execute();
            yield return new WaitForSeconds(delayBetweenActions);
        }
    }
}

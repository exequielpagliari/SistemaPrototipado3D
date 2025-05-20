using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase dedicada a la activación de múltiples IAction tanto de una vez como en secuencia.
/// </summary>
public class ActionChainer : MonoBehaviour, IAction
{
    /// <summary>
    /// Lista de IAction.
    /// </summary>
    public List<MonoBehaviour> actions = new();
    /// <summary>
    /// Bool para activar activación en secuencia o no.
    /// </summary>
    public bool runInSequence = false;
    /// <summary>
    /// Float que controla el delay de la corrutina de activación.
    /// </summary>
    public float delayBetweenActions = 0.5f;


    /// <summary>
    /// Método público para iniciar la ejeccución.
    /// </summary>
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

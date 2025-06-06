using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
    /// <summary>
    /// Clase dedicada a la activaci�n de m�ltiples IAction tanto de una vez como en secuencia.
    /// </summary>
    public class ActionChainer : MonoBehaviour, IAction
    {
        /// <summary>
        /// Lista de IAction.
        /// </summary>
        public List<MonoBehaviour> actions = new();
        /// <summary>
        /// Bool para activar activaci�n en secuencia o no.
        /// </summary>
        public bool runInSequence = false;
        /// <summary>
        /// Float que controla el delay de la corrutina de activaci�n.
        /// </summary>
        public float delayBetweenActions = 0.5f;


        /// <summary>
        /// M�todo p�blico para iniciar la ejeccuci�n.
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
}
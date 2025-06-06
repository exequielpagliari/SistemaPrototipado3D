using UnityEngine;
using UnityEditor;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Activators
{
    /// <summary>
    /// Clase dedicada a la emisi�n de un evento cuando una interfaz IActivator ejecuta Activate.
    /// </summary>
    public class VolumenInteractable : MonoBehaviour, IInteractable
    {
        /// <summary>
        /// Enum dedicado a la selecci�n de canal para evento.
        /// </summary>
        [DrawEventConnection("channelToActivate")]
        public EventChannelID channelToActivate;

        /// <summary>
        /// Bool activa el LogWarning para test de funcionamiento.
        /// </summary>
        public bool log;
        /// <summary>
        /// String que se representar� en la UI.
        /// </summary>
        public string actionString;
        public string GetInteractionPrompt() => actionString;


        /// <summary>
        /// M�todo �nico para realizar una activaci�n.
        /// </summary>
        public void Interact()
        {
            if (log)
                Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
            EventChannelManager.RaiseEvent(channelToActivate);
        }

    }
}
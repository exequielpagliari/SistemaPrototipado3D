using UnityEngine;
using UnityEditor;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Activators
{
    /// <summary>
    /// Clase dedicada a la emisión de un evento cuando una interfaz IActivator ejecuta Activate.
    /// </summary>
    public class VolumenInteractable : MonoBehaviour, IInteractable
    {
        /// <summary>
        /// Enum dedicado a la selección de canal para evento.
        /// </summary>
        [DrawEventConnection("channelToActivate")]
        public EventChannelID channelToActivate;

        /// <summary>
        /// Bool activa el LogWarning para test de funcionamiento.
        /// </summary>
        public bool log;
        /// <summary>
        /// String que se representará en la UI.
        /// </summary>
        public string actionString;
        public string GetInteractionPrompt() => actionString;


        /// <summary>
        /// Método único para realizar una activación.
        /// </summary>
        public void Interact()
        {
            if (log)
                Debug.Log($"[ButtonActivator] Activando canal {channelToActivate}");
            EventChannelManager.RaiseEvent(channelToActivate);
        }

    }
}

using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Activators
{
    /// <summary>
    /// Clase dedicada a la emisi�n de un evento cuando una interfaz IActivator ejecuta Activate.
    /// </summary>
    public class VolumenAutoInteractable : MonoBehaviour, IInteractable
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
        /// <summary>
        /// Get de String para IInteractable.
        /// </summary>
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IActor>(out var receiver))
            {
                Interact();
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IActor>(out var receiver))
            {
                Interact();
            }
        }

    }
}
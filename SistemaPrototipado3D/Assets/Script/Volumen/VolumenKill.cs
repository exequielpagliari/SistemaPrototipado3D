using UnityEngine;
using Prototipe.Core.Interfaces;


namespace Prototipe.Core.Activators
{
    /// <summary>
    /// Clase dedicada destrucci�n de un IActor y a la emisi�n de un evento cuando una interfaz IActivator ejecuta Activate.
    /// </summary>
    public class VolumenKill : MonoBehaviour
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
        /// M�todo que emite evento y llama al m�todo Dead() de un IActor.
        /// </summary>
        public void Kill(IActor actor)
        {
            if (log)
                Debug.Log($"[VolumenKill] Activando canal {channelToActivate}");
            EventChannelManager.RaiseEvent(channelToActivate);
            actor.Dead();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IActor>(out var receiver))
            {
                Kill(receiver);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IActor>(out var receiver))
            {
                Kill(receiver);
            }
        }

    }
}
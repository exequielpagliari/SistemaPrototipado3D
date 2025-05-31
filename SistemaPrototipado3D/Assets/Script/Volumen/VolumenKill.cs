using UnityEngine;
using Prototipe.Core.Interfaces;


namespace Prototipe.Core.Activators
{
    /// <summary>
    /// Clase dedicada destrucción de un IActor y a la emisión de un evento cuando una interfaz IActivator ejecuta Activate.
    /// </summary>
    public class VolumenKill : MonoBehaviour
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
        /// Método que emite evento y llama al método Dead() de un IActor.
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
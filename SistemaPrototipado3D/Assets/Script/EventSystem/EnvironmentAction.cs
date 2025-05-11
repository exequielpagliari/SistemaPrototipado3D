using UnityEngine;

public abstract class EnvironmentAction : MonoBehaviour
{
    /// <summary>
    /// Ejecuta la acción asociada al evento (animación, movimiento, cambio de estado, etc).
    /// </summary>
    public abstract void Execute();
}

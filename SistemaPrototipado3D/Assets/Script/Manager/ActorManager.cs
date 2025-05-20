using UnityEngine;

/// <summary>
/// Clase dedicada a la manipualación de Actores.
/// </summary>
public class ActorManager : MonoBehaviour
{
    /// <summary>
    /// Metodo de creacción de GameObjects.
    /// </summary>
    /// <param name="gameObject">GameObject a instanciar.</param>
    /// <param name="transform">Transform de ubicación a instanciar.</param>
    /// <param name="rotation">Rotación para instanciar.</param>
    public void Build(GameObject gameObject, Transform transform, Quaternion rotation)
    {
        GameObject go = Instantiate(gameObject, transform.position, rotation, null);

    }
}

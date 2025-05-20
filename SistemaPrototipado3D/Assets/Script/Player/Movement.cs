using UnityEngine;


/// <summary>
/// Controla el movimiento del Player utilizando el Transform.
/// </summary>
public class Movement : MonoBehaviour
{
    /// <summary>
    /// Velocidad base del movimiento del jugador.
    /// </summary>
    public float speed = 10f;

    void Update()
    {
        transform.Translate(InputManager.Instance.MoveInput.x * speed * Time.deltaTime, transform.position.y, InputManager.Instance.MoveInput.y * speed * Time.deltaTime);
    }
}

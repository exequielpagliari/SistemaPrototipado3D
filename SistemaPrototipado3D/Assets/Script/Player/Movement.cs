using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(InputManager.Instance.MoveInput.x * speed * Time.deltaTime, transform.position.y, InputManager.Instance.MoveInput.y * speed * Time.deltaTime);
    }
}

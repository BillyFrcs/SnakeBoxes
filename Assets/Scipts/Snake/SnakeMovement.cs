using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float SnakeSpeed;
    public float SteerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SnakeSpeed = 5.0f;
        SteerSpeed = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SnakeTranform();
    }

    private void SnakeTranform()
    {
        // Move snake forward
        transform.position += transform.forward * SnakeSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
    }
}

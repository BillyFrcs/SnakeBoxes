using UnityEngine;

namespace Player
{
    public class SnakeMovement : MonoBehaviour
    {
        public float SnakeSpeed;
        public float SteerSpeed;

        public static SnakeMovement InstanceSnakeMovement;

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceSnakeMovement != null)
            {
                InstanceSnakeMovement = this;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            SnakeTranform();
        }

        private void SnakeTranform()
        {
            // Move snake forward
            gameObject.transform.position += transform.forward * SnakeSpeed * Time.deltaTime;

            float steerDirection = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SnakeController : MonoBehaviour
    {
        [Tooltip("Body Prefab")] public GameObject BodyPrefab;
        [Tooltip("Snake Dead VFX")] public GameObject[] DeadVFX;

        [HideInInspector] public List<GameObject> BodyParts;
        private List<Vector3> PositionHistory;

        [SerializeField] private Material _SnakeMaterial;

        public static SnakeController InstanceSnakeController;

        private SnakeMovement _Movement;

        public int gap;
        public float bodySpeed;

        private void Awake()
        {
            BodyParts = new List<GameObject>();

            PositionHistory = new List<Vector3>();

            _Movement = FindObjectOfType(typeof(SnakeMovement)) as SnakeMovement;
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceSnakeController == null)
            {
                InstanceSnakeController = this;
            }

            _SnakeMaterial.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);;
        }

        // Update is called once per frame
        private void Update()
        {
            SnakeControl();
        }

        private void SnakeControl()
        {
            int index = 0;

            // Store position history
            PositionHistory.Insert(index, transform.position);

            // Update snake body parts
            foreach (var body in BodyParts)
            {
                Vector3 Point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];

                Vector3 MoveDirection = Point - body.transform.position;

                body.transform.position += bodySpeed * Time.deltaTime * MoveDirection;

                body.transform.LookAt(Point);

                index++;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Add body parts when snake eat food
            if (other.gameObject.CompareTag("Food"))
            {
                GrowSnake();
            }
        }

        private void GrowSnake()
        {
            GameObject BodySnake = Instantiate(BodyPrefab);

            BodyParts.Add(BodySnake);

            const float speed = 6.5f;

            const float newSpeed = 7.0f;

            const float maxSpeed = 8.0f;

            // Increase snake movement speed
            if (BodyParts.Count >= 5)
            {
                _Movement.SnakeSpeed = speed;

                bodySpeed = speed;

                if (BodyParts.Count >= 50)
                {
                    _Movement.SnakeSpeed = newSpeed;

                    bodySpeed = newSpeed;

                    if (BodyParts.Count >= 90)
                    {
                        _Movement.SnakeSpeed = maxSpeed;

                        bodySpeed = maxSpeed;
                    }
                }
            }
        }

        public void InstantiateDeadVFX()
        {
            foreach (var dead in DeadVFX)
            {
                Instantiate(dead, transform.position, Quaternion.identity);
            }
        }

        public Color SnakeColor
        {
            get
            {
                return _SnakeMaterial.color;
            }
        }
    }
}

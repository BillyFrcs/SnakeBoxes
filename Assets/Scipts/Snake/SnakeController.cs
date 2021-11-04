using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{   
    [Tooltip("Body Snake")] public GameObject BodyPrefab;

    [HideInInspector] public List<GameObject> BodyParts;
    private List<Vector3> PositionHistory;

    public static SnakeController InstanceSnakeController;

    public int gap;
    public int bodySpeed;

    private void Awake()
    {
        BodyParts = new List<GameObject>();

        PositionHistory = new List<Vector3>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gap = 10;
        bodySpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        SnakeControl();
    }

    private void SnakeControl()
    {
        // Store position history
        PositionHistory.Insert(0, transform.position);

        int index = 0;

        // Update snake body parts
        foreach (var body in BodyParts)
        {
            Vector3 Point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];

            Vector3 MoveDirection = (Point - body.transform.position);

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
        GameObject Body = Instantiate(BodyPrefab);

        BodyParts.Add(Body);
    }
}

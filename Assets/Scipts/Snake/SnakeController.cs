using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject BodyPrefab;

    public static List<GameObject> BodyParts;
    private List<Vector3> PositionHistory;

    public int Gap;
    public int BodySpeed;

    public SnakeController()
    {
        BodyParts = new List<GameObject>();
        PositionHistory = new List<Vector3>();

        Gap = 10;
        BodySpeed = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start the snake body parts
        GrowSnake();
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
            Vector3 Point = PositionHistory[Mathf.Min(index * Gap, PositionHistory.Count - 1)];

            Vector3 MoveDirection = (Point - body.transform.position);

            body.transform.position += MoveDirection * BodySpeed * Time.deltaTime;

            body.transform.LookAt(Point);

            index++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add body parts when snake eat food
        if (other.tag == "Food")
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

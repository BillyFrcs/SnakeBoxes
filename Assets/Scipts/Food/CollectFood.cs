using UnityEngine;

public class CollectFood : MonoBehaviour
{
    private SpawnFood _Food;

    private bool _isAte = false;

    // Start is called before the first frame update
    void Start()
    {
        _Food = FindObjectOfType(typeof (SpawnFood)) as SpawnFood;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        _isAte = true;

        if (_isAte)
        {
            _Food.SpawnRandomFood();

            // Get the score when collide with food
            ScoreSystem.Score++;
        }

        Destroy(gameObject);
    }
}
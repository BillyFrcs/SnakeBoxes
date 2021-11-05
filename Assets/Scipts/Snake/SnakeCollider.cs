using UnityEngine;

public class SnakeCollider : MonoBehaviour
{
    private GameObject _SpawnFood;

    private SnakeController _Snake;

    // Start is called before the first frame update
    void Start()
    {
        _SpawnFood = GameObject.Find("Spawn Food");

        _Snake = FindObjectOfType(typeof(SnakeController)) as SnakeController;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Body"))
        {
            const float timeDelay = 1.0f;

            // Display game over screen
            Invoke(nameof(DisplayGameOverScreen), timeDelay);

            // Display score game
            Invoke(nameof(DisplayScoreGame), timeDelay);

            // Display best score player
            ScoreSystem.InstanceScoreSystem.ScorePlayer();

            if (SnakeController.InstanceSnakeController != null)
            {
                SnakeController.InstanceSnakeController.InstantiateDeadVFX();
            }

            // Destroy spawn food if snake is dead
            DestroySpawnFood();

            Destroy(collision.gameObject);
        }
    }

    private void DisplayGameOverScreen()
    {
        GameOver.InstanceGameover.DisplayGameOver.SetActive(true);

        // Reset score
        ScoreSystem.InstanceScoreSystem.ResetScoreGame();
    }

    private void DisplayScoreGame()
    {
        ScoreSystem.InstanceScoreSystem.Score.SetActive(false);
    }

    private void DestroySpawnFood()
    {
        if (_SpawnFood != null)
        {
            Destroy(_SpawnFood);
        }
    }
}

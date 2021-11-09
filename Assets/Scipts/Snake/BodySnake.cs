using UnityEngine;

public class BodySnake : MonoBehaviour
{
    private GameObject _SnakeObject;

    private ScoreSystem _ScoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        _SnakeObject = GameObject.FindGameObjectWithTag("Player");

        _ScoreSystem = FindObjectOfType(typeof(ScoreSystem)) as ScoreSystem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            if (SnakeController.InstanceSnakeController != null)
            {
                SnakeController.InstanceSnakeController.InstantiateDeadVFX();
            }

            _ScoreSystem.ScorePlayer();

            DisplayGameOverScreen();

            DisplayScoreGame();

            Destroy(_SnakeObject);

            // Debug.LogAssertion("Game Over"); // DEBUG ASSERT
        }
    }

    private void DisplayScoreGame()
    {
        ScoreSystem.InstanceScoreSystem.Score.SetActive(false);
    }

    private void DisplayGameOverScreen()
    {
        GameOver.InstanceGameover.DisplayGameOver.SetActive(true);

        // Reset score
        ScoreSystem.InstanceScoreSystem.ResetScoreGame();
    }
}

using UnityEngine;

public enum ResetScore
{
    SCORE = 0
}

public class SnakeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            GameOver.InstanceGameover.DisplayGameOver.SetActive(true);

            ScoreSystem.InstanceScoreSystem.Score.SetActive(false);

            SnakeController.BodyParts.Clear();
        }
    }

    private void Reset()
    {
        // Reset score game
        ScoreSystem.score = (int)ResetScore.SCORE;

        // Debug.Log("Game Over"); // DEBUG
    }
}

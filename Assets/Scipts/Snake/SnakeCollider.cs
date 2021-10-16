using UnityEngine;
using UnityEngine.SceneManagement;

public enum ResetScore
{
    SCORE = 0
}

public class SnakeCollider : MonoBehaviour
{
    [SerializeField]
    private float RestartDelay;

    // Start is called before the first frame update
    void Start()
    {
        RestartDelay = 1.0f;
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
            
            SnakeController.BodyParts.Clear();

            // Reset game when crash with sides
            Invoke("Reset", RestartDelay);
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset score game
        ScoreSystem.Score = (int)ResetScore.SCORE;

        // SceneManager.LoadScene("GamePlay");

        // Debug.Log("Game Over"); // DEBUG
    }
}

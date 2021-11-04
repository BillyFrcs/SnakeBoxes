using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject DisplayGameOver;

    public static GameOver InstanceGameover;

    // Start is called before the first frame update
    void Start()
    {
        if (InstanceGameover == null)
        {
            InstanceGameover = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        DisplayGameOver.SetActive(false);

        ScoreSystem.InstanceScoreSystem.Score.SetActive(true);
    }
}

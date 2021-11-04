using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject DisplayGameOver;

    [SerializeField] private GameObject _MainMenu;

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
        PlayClickSound();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        DisplayGameOver?.SetActive(false);

        _MainMenu?.SetActive(false);

        SpawnSnake.InstanceSpawnSnake.InstantiateSnake();

        ScoreSystem.InstanceScoreSystem.Score.SetActive(true);
    }

    public void Exit()
    {
        DisplayGameOver?.SetActive(false);

        _MainMenu?.SetActive(true);
    }

    private static void PlayClickSound()
    {
        SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
    }
}

using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _Score;

    public GameObject MainMenuGame;

    public static MainMenu InstaceMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuGame = GameObject.Find("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        StartGamePlay();

        DeactivatedMainMenu();
    }

    private void StartGamePlay()
    {
        PlayClickSound();

        SpawnSnake.InstanceSpawnSnake.InstantiateSnake();

        _Score.SetActive(true);
    }

    private void DeactivatedMainMenu()
    {
        MainMenuGame.SetActive(false);
    }

    public void QuitGame()
    {
        PlayClickSound();

        Application.Quit();

        Debug.LogAssertionFormat("Quit game!"); // DEBUG LOG ASSERT
    }

    private static void PlayClickSound() => SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
}

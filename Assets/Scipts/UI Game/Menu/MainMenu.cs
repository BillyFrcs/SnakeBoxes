using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _Score;

    [Tooltip("Main Menu")]public GameObject MainMenuGame;
    [HideInInspector] public GameObject Footer; 

    public static MainMenu InstanceMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuGame = GameObject.Find("Main Menu");

        Footer = GameObject.Find("Bilix Games");

        if (InstanceMainMenu == null)
        {
            InstanceMainMenu = this;
        }
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

        UIAnimation.InstanceUIAnimation.PlayButtonAnimation();

        Footer.SetActive(false);

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
                            
        // Debug.LogAssertionFormat("Quit game!"); // DEBUG LOG ASSERT
    }

    private static void PlayClickSound() => SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
}
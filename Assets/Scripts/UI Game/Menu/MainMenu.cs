using UnityEngine;
using Sounds;
using Player;

namespace UIGame
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _Score;

        [Tooltip("Main Menu")] public GameObject MainMenuGame;
        public GameObject Credits;

        public static MainMenu InstanceMainMenu;

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceMainMenu == null)
            {
                InstanceMainMenu = this;
            }
        }

        public void PlayGame()
        {
            StartGamePlay();

            DeactivatedMainMenu();
        }

        private void StartGamePlay()
        {
            PlayClickSound();
            
            Credits.SetActive(false);
            
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
}

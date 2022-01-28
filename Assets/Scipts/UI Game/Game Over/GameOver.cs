using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sounds;
using Player;

namespace UIGame
{
    public class GameOver : MonoBehaviour
    {
        public GameObject DisplayGameOver;

        [SerializeField] private GameObject _MainMenu;

        public static GameOver InstanceGameover;

        // Start is called before the first frame update
        private void Start()
        {
            if (InstanceGameover == null)
            {
                InstanceGameover = this;
            }
        }

        public void DisplayGameOverScreen()
        {
            DisplayGameOver.SetActive(true);
            
            // Save high score
            ScoreSystem.InstanceScoreSystem.SaveBestScorePlayer();

            // Reset score
            ScoreSystem.InstanceScoreSystem.ResetScoreGame();
        }
        
        public void TryAgain()
        {
            PlayClickSound();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            DisplayGameOver.SetActive(false);

            _MainMenu.SetActive(false);

            SpawnSnake.InstanceSpawnSnake.InstantiateSnake();
            
            ScoreSystem.InstanceScoreSystem.Score.SetActive(true);
        }

        public void Exit()
        {
            PlayClickSound();

            DisplayGameOver.SetActive(false);

            _MainMenu.SetActive(true);
        }

        private static void PlayClickSound()
        {
            SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
        }
    }
}

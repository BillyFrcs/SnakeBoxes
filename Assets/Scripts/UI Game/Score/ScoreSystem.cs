using UnityEngine;
using TMPro;
using Sounds;

namespace UIGame
{
    public enum ResetScore
    {
        SCORE = 0
    }

    public class ScoreSystem : MonoBehaviour
    {
        [Header("Score Game")] 
        [SerializeField] private TextMeshProUGUI _Score;

        private int _score = 0;

        [Header("Best Score")] 
        [SerializeField] private TextMeshProUGUI _HighScore;

        private int _highScore = 0;

        [Tooltip("Score Reference")] public GameObject Score;

        public static ScoreSystem InstanceScoreSystem;

        private void Awake()
        {
            if (InstanceScoreSystem == null)
            {
                InstanceScoreSystem = this;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _highScore = PlayerPrefs.GetInt("High Score", 0);

            _HighScore.text = "Your High Score: " + _highScore.ToString();
        }

        // Update is called once per frame
        private void Update()
        {
            // Update collect food score
            _Score.text = "Your Score: " + _score.ToString();
        }
        
        public void DisplayScoreGame()
        {
            Score.SetActive(false);
        }

        public void SaveBestScorePlayer()
        {
            LoadBestScoreGame();
            
            if (_score > PlayerPrefs.GetInt("High Score", 0))
            {
                PlayerPrefs.SetInt("High Score", _score);

                _HighScore.text = $"Your High Score: {_score.ToString()}";

                // Debug.Log("Score player"); // DEBUG
            }
        }

        private void LoadBestScoreGame()
        {
            if (PlayerPrefs.HasKey("High Score"))
            {
                _highScore = PlayerPrefs.GetInt("High Score", 0);
                
                _HighScore.text = $"Your High Score: {_highScore.ToString()}";

                // Debug.Log("Load high score"); // DEBUG
            }
        }

        public int IncreaseScoreGame
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        public int ResetScoreGame()
        {
            // Reset score game
            return _score = (int) ResetScore.SCORE;
        }

        public void ResetBestScoreGame()
        {
            PlayerPrefs.DeleteKey("High Score");

            _HighScore.text = "Your High Score: " + ResetScoreGame();

            SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
        }
    }
}

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
        [Header("Score Game")] [SerializeField]
        private TextMeshProUGUI _Score;

        public static int score = 0;

        [Header("Best Score")] [SerializeField]
        private TextMeshProUGUI _BestScore;

        private int _bestScore = 0;

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
            _bestScore = PlayerPrefs.GetInt("Best Score", 0);

            _BestScore.text = "Your Best Score: " + _bestScore.ToString();
        }

        // Update is called once per frame
        private void Update()
        {
            // Update collect food score
            _Score.text = "Your Score: " + score.ToString();
        }

        public void ScorePlayer()
        {
            if (score > PlayerPrefs.GetInt("Best Score", 0))
            {
                PlayerPrefs.SetInt("Best Score", score);

                _BestScore.text = "Your Best Score: " + score.ToString();

                // Debug.Log("Score player"); // DEBUG
            }
        }

        public void ResetScoreGame()
        {
            // Reset score game
            score = (int) ResetScore.SCORE;
        }

        public void ResetBestScoreGame()
        {
            PlayerPrefs.DeleteKey("Best Score");

            _BestScore.text = "Your Best Score: " + (int) ResetScore.SCORE;

            SoundEffectManager.InstanceSoundEffectManager.PlaySoundEffect("Click");
        }
    }
}

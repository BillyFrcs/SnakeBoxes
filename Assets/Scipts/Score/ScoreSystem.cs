using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ScoreTPM;

    public GameObject Score;

    public static ScoreSystem InstanceScoreSystem;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {    
        if (InstanceScoreSystem == null)
        {
            InstanceScoreSystem = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update collect food score
        _ScoreTPM.text = "Your Score: " + score.ToString();
    }
}

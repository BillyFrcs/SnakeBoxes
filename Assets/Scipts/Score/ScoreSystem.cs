using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject ScoreGame;

    public static int Score;

    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        // Update collect food score
        ScoreGame.GetComponent<Text>().text = "Score: " + Score.ToString();
    }
}

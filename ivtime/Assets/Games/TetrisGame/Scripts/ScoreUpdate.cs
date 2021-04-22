using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public int score;
    public Text scoretxt;
    void Start()
    {
        PlayerPrefs.SetInt("ScoreTetris", 0);
        scoretxt.text = "0" + 0 + "/10";
    }
    void Update()
    {
        score = PlayerPrefs.GetInt("ScoreTetris");
        scoretxt.text = "0" + score + "/10";
    }
}

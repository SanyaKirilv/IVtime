using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [Header("Panel")]
    public GameObject Panel;
    private void Start()
    {
        NoRestart();
    }
    public void NoRestart()
    {
        Panel.SetActive(false);
    }
    public void YesRestart()
    {
        PlayerPrefs.DeleteKey("Part");
        PlayerPrefs.DeleteKey("Phase");
        PlayerPrefs.DeleteKey("Load");
        PlayerPrefs.DeleteKey("Move");
        PlayerPrefs.DeleteKey("Game");
        PlayerPrefs.DeleteKey("ScoreTetris");
        SceneManager.LoadScene("Menu(Intro)");
    }
    public void RestartAPP()
    {
        Panel.SetActive(true);
    }
}

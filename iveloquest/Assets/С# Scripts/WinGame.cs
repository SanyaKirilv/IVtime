using UnityEngine;
using UnityEngine.UI;
public class WinGame : MonoBehaviour
{
    public GameObject UI;
    public GameObject game;
    public GameObject gameTextUI;
    public GameObject Sound;
    [TextArea]
    public string wintxt;
    void Start()
    {
        gameTextUI.GetComponent<Text>().text = " ";
        UI.SetActive(false);
        game.SetActive(true);
        Sound.SetActive(true);
    }
    public void FinishGame()
    {
        game.SetActive(false);
        UI.SetActive(true);
        gameTextUI.GetComponent<Text>().text = wintxt;
        Sound.SetActive(false);
    }
    public void FindOBJ()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        game = GameObject.FindGameObjectWithTag("RawImg");
        gameTextUI = GameObject.FindGameObjectWithTag("GameText");
    }
    public void StartGame()
    {
        FindOBJ();
        gameTextUI.GetComponent<Text>().text = " ";
        UI.SetActive(false);
        game.SetActive(true);
    }
}

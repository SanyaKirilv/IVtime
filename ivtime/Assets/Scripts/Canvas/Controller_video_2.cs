using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Controller_video_2 : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    //[Header("Names")]
    //public string[] name;
    [Header("Clips")]
    public VideoClip[] clip;
    [Header("Part's")]
    public int part;
    public int new_part;
    [Header("Current Phase")]
    public int phase;
    [Header("Button")]
    public GameObject button;
    [Header("UI")]
    [TextArea]
    public string[] panel_txt;
    public Text textArea;
    public GameObject panel;
    [Header("Timer")]
    public Text timer;
    public GameObject Timer_obj;
    [Header("Time")]
    public float time;
    string seconds;
    string minutes;

    void Start()
    {
        //PlayerPrefs.SetInt("Phase", 1);
        part = PlayerPrefs.GetInt("Part");
        phase = PlayerPrefs.GetInt("Phase");
        if (phase <= 0)
        {
            PlayerPrefs.SetInt("Phase", 1);
            phase = 1;
        }
    }
    void Update()
    {
        phase = PlayerPrefs.GetInt("Phase");
        Videos();
    }
    private void Videos()
    { 
        switch (phase)
        {
            case 1:
                //video.url = "http://alexa9d5.beget.tech/" + name[0];
                video.clip = clip[0];
                button.SetActive(false);
                panel.SetActive(false);
                Timer_obj.SetActive(false);
                if (video.isPaused)
                {
                    PlayerPrefs.SetInt("Phase", 2);
                }
                break;
            case 2:
                //video.url = "http://alexa9d5.beget.tech/" + name[1];
                video.clip = clip[1];
                panel.SetActive(false);
                button.SetActive(true);
                Timer_obj.SetActive(false);
                if (video.isPaused)
                {
                    Timer_obj.SetActive(true);                  
                    time -= Time.deltaTime;
                    seconds = (time % 60).ToString("00");
                    minutes = (Mathf.Floor((time / 3600) * 60)).ToString("00");
                    timer.text = minutes + ":" + seconds;
                    if (time <= 0)
                    {
                        time = 10;
                        PlayerPrefs.SetInt("Phase", 3);
                    }
                }
                break;
            case 3:
                panel.SetActive(true);
                button.SetActive(true);
                Timer_obj.SetActive(true);
                textArea.text = panel_txt[0];
                time -= Time.deltaTime;
                seconds = (time % 60).ToString("00");
                minutes = (Mathf.Floor((time / 3600) * 60)).ToString("00");
                timer.text = minutes + ":" + seconds;
                if (time <= 0)
                {
                    time = 10; //!
                    PlayerPrefs.SetInt("Phase", 4);
                }
                break;
            case 4:
                Timer_obj.SetActive(false);
                panel.SetActive(true);
                textArea.text = panel_txt[1];
                break;
        }
    }
    public void Load()
    {
        PlayerPrefs.SetInt("AR", 0);
        SceneManager.LoadScene("Loader");
    }
}

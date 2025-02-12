using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;

public class Controller_video_2 : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    //public bool isStoped = false;
    [Header("Clips")]
    public VideoClip[] clip;
    [Header("Part's")]
    public int part;
    public int new_part;
    [Header("Phase")]
    public int phase;
    [Header("Button's")]
    public Button buttonAR;
    public Button buttonSpeed;
    public Button buttonInfo;
    [Header("UI")]
    [TextArea]
    public string[] panel_txt;
    public Text textArea;
    public bool text_s = false;
    public Text txt;
    public GameObject panel;
    [Header("Timer")]
    public Text timer;
    public GameObject Timer_obj;
    [Header("Time")]
    public bool isPaused = false;
    public bool isChanged = false;
    TimeSpan ts;
    public float time;
    string seconds;
    string minutes;

    void Start()
    {
        part = PlayerPrefs.GetInt("Part");
        phase = PlayerPrefs.GetInt("Phase");
        if (text_s)
        {
            txt.text = " ";
        }
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
                video.clip = clip[0];
                buttonAR.interactable = false;
                buttonSpeed.interactable = true;
                buttonInfo.interactable = true;
                panel.SetActive(false);
                Timer_obj.SetActive(false);
                if (video.isPaused)
                {
                    time = 299;
                    PlayerPrefs.SetFloat("GameTime", 299);
                    PlayerPrefs.SetInt("Phase", 2);
                }
                break;
            case 2:
                video.clip = clip[1];
                panel.SetActive(false);
                buttonAR.interactable = true;
                buttonSpeed.interactable = true;
                buttonInfo.interactable = true;
                Timer_obj.SetActive(false);
                if (video.isPaused)
                {
                    if (text_s)
                    {
                        txt.text = "Next point is…. One шагова.";
                    }
                    Timer_obj.SetActive(true);                  
                    time -= Time.deltaTime;
                    seconds = (time % 60).ToString("00");
                    minutes = (Mathf.Floor((time / 3600) * 60)).ToString("00");
                    timer.text = minutes + ":" + seconds;
                    if (time <= 0)
                    {
                        time = 299;
                        PlayerPrefs.SetFloat("GameTime", 299);
                        PlayerPrefs.SetInt("Phase", 3);
                    }
                }
                break;
            case 3:
                panel.SetActive(true);
                buttonAR.interactable = true;
                buttonSpeed.interactable = true;
                buttonInfo.interactable = true;
                Timer_obj.SetActive(true);
                textArea.text = panel_txt[0];
                time -= Time.deltaTime;
                seconds = (time % 60).ToString("00");
                minutes = (Mathf.Floor((time / 3600) * 60)).ToString("00");
                timer.text = minutes + ":" + seconds;
                if (time <= 0)
                {
                    time = 299;
                    PlayerPrefs.SetFloat("GameTime", 299);
                    PlayerPrefs.SetInt("Phase", 4);
                }
                break;
            case 4:
                Timer_obj.SetActive(false);
                panel.SetActive(true);
                buttonAR.interactable = true;
                buttonSpeed.interactable = true;
                buttonInfo.interactable = true;
                textArea.text = panel_txt[1];
                break;
        }
    }
    void PausePlayTime()
    {
        if (isPaused)
        {
            PlayerPrefs.SetFloat("GameTime", time);
            PlayerPrefs.SetString("PhoneTime", DateTime.Now.ToString());
            isChanged = false;
        }
        if (!isChanged || !isPaused)
        {
            if (PlayerPrefs.HasKey("PhoneTime") && PlayerPrefs.HasKey("GameTime"))
            {
                ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("PhoneTime"));
                time = PlayerPrefs.GetFloat("GameTime") - (ts.Seconds + ts.Minutes*60);
                Debug.Log(PlayerPrefs.GetFloat("GameTime") - ts.Seconds);
            }
            isChanged = true;
        }
    }
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
        PausePlayTime();
    }
    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        PausePlayTime();
    }
    //public void PausePlayVideo()
    //{
    //    if (isStoped)
    //    {
    //        video.playbackSpeed = 1f;
    //    }
    //    else
    //    {
    //        video.playbackSpeed = 0f;
    //    }
    //    isStoped = !isStoped;
    //}
    public void Load()
    {
        PlayerPrefs.SetInt("Load", 1);
        SceneManager.LoadScene("Loader");
    }
}

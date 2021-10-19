using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Controller_video_1 : MonoBehaviour
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
    [Header("Button")]
    public Button button;
    void Start()
    {
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

                video.clip = clip[0];
                button.interactable = false;
                if (video.isPaused)
                {
                    PlayerPrefs.SetInt("Phase", 2);
                }
                break;
            case 2:
                video.clip = clip[1];
                button.interactable = false;
                if (video.isPaused)
                {
                    PlayerPrefs.SetInt("Phase", 3);;
                }
                break;
            case 3:
                video.clip = clip[2];
                button.interactable = false;
                if (video.isPaused)
                {
                    button.interactable = true;
                }
                break;
        }
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
        if (part < new_part)
        {
            PlayerPrefs.SetInt("Part", new_part);
            PlayerPrefs.SetInt("Phase", 0);
            SceneManager.LoadScene("Loader");
        }
    }
}

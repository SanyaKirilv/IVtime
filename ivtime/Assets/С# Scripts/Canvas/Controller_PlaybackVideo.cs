using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Controller_PlaybackVideo : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    [Header("Button")]
    public Text bt;
    private int vs;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("VideoSpeed"))
        {
            PlayerPrefs.SetInt("VideoSpeed", 0);
            vs = 0;
        }
        ChangeSpeed();
    }
    public void ChangeSpeed()
    {
        vs = PlayerPrefs.GetInt("VideoSpeed");
        switch (vs)
        {
            case 0:
                video.playbackSpeed = 1f;
                bt.text = "1X";
                break;
            case 1:
                video.playbackSpeed = 1.5f;
                bt.text = "2X";
                break;
        }
    }
    public void Change()
    {
        vs = PlayerPrefs.GetInt("VideoSpeed");
        switch (vs)
        {
            case 0:
                PlayerPrefs.SetInt("VideoSpeed", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("VideoSpeed", 0);
                break;
        }
        ChangeSpeed();
    }
}

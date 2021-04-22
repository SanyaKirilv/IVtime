using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Controller_video_1 : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    [Header("Clips")]
    public VideoClip[] clip; 
    [Header("Part's")]
    public int part;
    public int new_part;
    [Header("Phase")]
    public int phase;
    [Header("Button")]
    public GameObject button;

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
                button.SetActive(false);
                if (video.isPaused)
                {
                    PlayerPrefs.SetInt("Phase", 2);
                }
                break;
            case 2:
                video.clip = clip[1];
                button.SetActive(false);
                if (video.isPaused)
                {
                    PlayerPrefs.SetInt("Phase", 3);;
                }
                break;
            case 3:
                video.clip = clip[2];
                button.SetActive(false);
                if (video.isPaused)
                {
                    button.SetActive(true);
                }
                break;
        }
    }
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

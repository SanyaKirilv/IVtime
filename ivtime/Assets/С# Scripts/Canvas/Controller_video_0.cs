using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Controller_video_0 : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    [Header("Clip")]
    public VideoClip clip;

    void Start()
    {
        video.clip = clip;
    }
    void Update()
    {
        if (video.isPaused)
        {
            PlayerPrefs.SetInt("Part", 1);
            SceneManager.LoadScene("Loader");
        }
    }
}


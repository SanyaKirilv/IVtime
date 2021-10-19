using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Controller_video_0 : MonoBehaviour
{
    [Header("VideoPlayer")]
    public VideoPlayer video;
    [Header("Clip")]
    public VideoClip clip;
    [Header("Switch")]
    public bool sw;
    [Header("Part's")]
    public int new_part;

    void Start()
    {
        video.clip = clip;
    }
    void Update()
    {
        if (video.isPaused)
        {
            if (sw)
            {
                PlayerPrefs.SetInt("Part", new_part);
                PlayerPrefs.SetInt("Phase", 0);
            }
            SceneManager.LoadScene("Loader");
        }
    }
}


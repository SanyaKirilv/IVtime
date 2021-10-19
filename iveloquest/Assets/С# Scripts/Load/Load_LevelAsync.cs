using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_LevelAsync : MonoBehaviour
{
    [Header("Part's")]
    public int part;
    public int load;
    [Header("Scenes")]
    public string[] scene;
    [Header("Level name")]
    public string code_name;
    [Header("Progress circle")]
    public Image loading_circle;
    [Header("Progress text")]
    public Text loading_text;

    void Start()
    {


        PlayerPreferences();
        part = PlayerPrefs.GetInt("Part");
        load = PlayerPrefs.GetInt("Load");
        Part();
        StartCoroutine(AsyncLoad());
    }
    public void Part()
    {
        if (load != 0)
        {
            switch (load)
            {
                case 1:
                    code_name = "AR";
                    PlayerPrefs.SetInt("Load", 0);
                    break;
                case 2:
                    code_name = "Tanks";
                    PlayerPrefs.SetInt("Load", 0);
                    break;
                case 3:
                    code_name = "Pacman";
                    PlayerPrefs.SetInt("Load", 0);
                    break;
                case 4:
                    code_name = "Tetris";
                    PlayerPrefs.SetInt("Load", 0);
                    break;
                case 5:
                    code_name = "Information";
                    PlayerPrefs.SetInt("Load", 0);
                    break;
            }  
        }
        else
        {
            code_name = scene[part];
        }
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(code_name);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loading_circle.fillAmount = progress; ;
            loading_text.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
    private void PlayerPreferences()
    {
        if (!PlayerPrefs.HasKey("Part"))
        {
            PlayerPrefs.SetInt("Part", 0);
        }
        if (!PlayerPrefs.HasKey("Phase"))
        {
            PlayerPrefs.SetInt("Phase", 0);
        }
        if (!PlayerPrefs.HasKey("Load"))
        {
            PlayerPrefs.SetInt("Load", 0);
        }
        if (!PlayerPrefs.HasKey("Share"))
        {
            PlayerPrefs.SetString("Share", "No");
        }
    }
}

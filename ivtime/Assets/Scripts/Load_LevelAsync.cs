using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_LevelAsync : MonoBehaviour
{
    [Header("Part's")]
    public int part;
    public int ar;
    public string[] scene;
    [Header("Level name")]
    public string code_name;
    [Header("Progress circle")]
    public Image loading_circle;
    [Header("Progress text")]
    public Text loading_text;

    void Start()
    {
        //PlayerPrefs.SetInt("Part", 0);
        if (!PlayerPrefs.HasKey("Part"))
        {
            PlayerPrefs.SetInt("Part", 0);
            part = 0;
        }
        if (!PlayerPrefs.HasKey("Phase"))
        {
            PlayerPrefs.SetInt("Phase", 0);
        }
        if (!PlayerPrefs.HasKey("AR"))
        {
            PlayerPrefs.SetInt("AR", 0);
            ar = 0;
        }
        part = PlayerPrefs.GetInt("Part");
        ar = PlayerPrefs.GetInt("AR");
        Part();
        StartCoroutine(AsyncLoad());
    }
    public void Part()
    {
        if (ar==1)
        {
            code_name = "AR";
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
}

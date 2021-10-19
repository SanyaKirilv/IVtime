using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    [Header("Scene number")]
    public int num;
    public void Load()
    {
        PlayerPrefs.SetInt("Load", num);
        SceneManager.LoadScene("Loader");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour
{
    [Header("Part's")]
    public int part;
    public int new_part;
    public void Load()
    {
        PlayerPrefs.SetInt("Part", new_part);
        PlayerPrefs.SetInt("Phase", 0);
        PlayerPrefs.SetInt("Load", 0);
        SceneManager.LoadScene("Loader");

    }
}

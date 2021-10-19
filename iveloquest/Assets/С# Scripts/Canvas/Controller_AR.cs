using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_AR : MonoBehaviour
{
    [Header("Part's")]
    public int part;
    public int new_part;
    [Header("Switch")]
    public bool sw;
    public int load;
    public void Load()
    {
        if (sw)
        {
            part = PlayerPrefs.GetInt("Part");
            PlayerPrefs.SetInt("Part", new_part);
            PlayerPrefs.SetInt("Phase", 0);
        }
        PlayerPrefs.SetInt("Load", load);
        SceneManager.LoadScene("Loader");
    }
}

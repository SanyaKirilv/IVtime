using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour
{
    [Header("AR/Menu")]
    public bool sw;
    public void Load()
    {
        if (sw)
        {
            PlayerPrefs.SetString("CodeName", "AR");
            SceneManager.LoadScene("Loader");
        }
        else
        {
            PlayerPrefs.SetString("CodeName", "Menu");
            SceneManager.LoadScene("Loader");
        }
         
    }
}

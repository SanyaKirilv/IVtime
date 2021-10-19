using UnityEngine;

public class CheckScript : MonoBehaviour
{
    [Header("Check Unlock")]
    public int unlock;
    [Header("Animation")]
    public Animation anim;
    [Header("UI")]
    public GameObject canvas_1;
    public GameObject canvas_2;
    void Start()
    {
        if (!PlayerPrefs.HasKey("CheckUnlock"))
        {
            PlayerPrefs.SetInt("CheckUnlock", 1);
            unlock = 1;
        }
        unlock = PlayerPrefs.GetInt("CheckUnlock");
        PlayerPreferences();
        Unlocked();
    }
    public void Scan()
    {
        anim.Play("Panel_check");
    }
    public void Unlock()
    {
        PlayerPrefs.SetInt("CheckUnlock", 1);
        Unlocked();
    }
    private void Unlocked()
    {
        unlock = PlayerPrefs.GetInt("CheckUnlock");
        switch (unlock)
        {
            case 0:
                canvas_1.SetActive(true);
                canvas_2.SetActive(false);
                break;
            case 1:
                canvas_1.SetActive(false);
                canvas_2.SetActive(true);
                break;
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
    }
}
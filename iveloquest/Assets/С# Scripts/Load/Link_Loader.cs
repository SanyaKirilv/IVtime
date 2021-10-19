using UnityEngine;

public class Link_Loader : MonoBehaviour
{
    [Header("Link")]
    public string link;
    public void Load()
    {
        Application.OpenURL(link);
    }
}

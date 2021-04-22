using UnityEngine;

public class Controller_Marker : MonoBehaviour
{
    [Header("Part")]
    public int part;
    [Header("Marker's")]
    public GameObject[] marker;
    void Start()
    {
        for (int i = 0; i < marker.Length; i ++)
        {
            marker[i].SetActive(false);
        }
        part = PlayerPrefs.GetInt("Part");
        marker[part - 2].SetActive(true);
    }
}


using UnityEngine;

public class MoveController : MonoBehaviour
{
    public void Rotate()
    {
        PlayerPrefs.SetString("Move", "rotate");
    }
    public void Down()
    {
        PlayerPrefs.SetString("Move", "down");
    }
    public void Right()
    {
        PlayerPrefs.SetString("Move", "right");
    }
    public void Left()
    {
        PlayerPrefs.SetString("Move", "left");
    }
}

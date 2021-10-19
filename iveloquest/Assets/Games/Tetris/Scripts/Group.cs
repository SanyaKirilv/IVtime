using UnityEngine;


public class Group : MonoBehaviour
{
    string moveTo;
    float lastFall = 0;
    void Start()
    {
        PlayerPrefs.SetString("Move", "");
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            PlayerPrefs.SetString("Game", "GO");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        moveTo = PlayerPrefs.GetString("Move");
        if (moveTo == "left")
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
            PlayerPrefs.SetString("Move", "");
        }

        else if (moveTo == "right")
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
            PlayerPrefs.SetString("Move", "");
        }

        else if (moveTo == "rotate")
        {
            transform.Rotate(0, 0, -90);

            if (isValidGridPos())
                updateGrid();
            else
                transform.Rotate(0, 0, 90);
            PlayerPrefs.SetString("Move", "");
        }

        else if ((moveTo == "down") ||
                 Time.time - lastFall >= 1)
        {

             transform.position += new Vector3(0, -1, 0);

             if (isValidGridPos())
             {
                updateGrid();
             }
             else
             {
                transform.position += new Vector3(0, 1, 0);
                Playfield.deleteFullRows();
                FindObjectOfType<Spawner>().spawnNext();
                enabled = false;
             }

            lastFall = Time.time;
            PlayerPrefs.SetString("Move", "");
        }
    }
    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            if (!Playfield.insideBorder(v))

                return false;
            if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void updateGrid()
    {
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
}

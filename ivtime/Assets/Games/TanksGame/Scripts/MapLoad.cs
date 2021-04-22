using UnityEngine;

public class MapLoad : MonoBehaviour {

    public WinGame WG;
    public Transform generatedWallFolder;
    public Transform generatedEnemyFolder;
    public Transform generatedBulletFolder;
    public Transform spawnLocation;
    public Transform powerUp;

    public Transform player1;

    public int level;

    public Transform wall;
    public Transform iron;
    public Transform bush;
    public Transform ice;
    public Transform water;
    public Transform gen;

    public AudioSource levelStarting;

    private bool multiplayer = false;
    private int currentLevel;

    string[] m = { "QQbb.....o..o.....bbQQ",
                   "QQbb.....o..o.....bbQQ",
                   "bboo.....oooo.....oobb",
                   "bbooo............ooobb",
                   "QQQooooooQQQQooooooQQQ",
                   "QQQQooooQQQQQQooooQQQQ",
                   "..........QQ..........",
                   "oooooo..........oooooo",
                   "oooooo..........oooooo",
                   "QQoo..............ooQQ",
                   "QQoo..............ooQQ",
                   "oo..................oo",
                   "oo.....Q......Q.....oo",
                   "ooQQ..Q........Q..QQoo",
                   "ooQQ...Q......Q...QQoo",
                   "..QQ..............QQ..",
                   "..QQ..............QQ..",
                   "bb..................bb",
                   "bb..................bb",
                   "oobb......QQ......bboo",
                   "oobb......QQ......bboo",
                   "QQoobbbbbbbbbbbbbbooQQ",
                   "QQoobbbbbbbbbbbbbbooQQ",
                   "oobb..............bboo",
                   "oobb..............bboo",
                   "bb..................bb",
                   "bb....ooo....ooo....bb",
                   "......................",
                   "......................",
                   "QQQQoo...oooo...ooQQQQ",
                   "QQQQoo...oooo...ooQQQQ",
                   "QQoo..............ooQQ",
                   "QQoo..............ooQQ",
                   "QQoo..............ooQQ",
                   "QQoo..............ooQQ" };

    void Start ()
    {
        WG.StartGame();
        LoadMap(level);

        Application.targetFrameRate = 60;
        QualitySettings.antiAliasing = 0;
        QualitySettings.shadowCascades = 0;
        QualitySettings.vSyncCount = 1;
        QualitySettings.SetQualityLevel(2);
    }

    void Update()
    {
        if (currentLevel != level)
        {
            LoadMap(level);
        }

    }
    public void GetMultiplayer(ArgsPointer<bool> pointer)
    {
        pointer.Args = new bool[] { multiplayer };
    }

    private void LoadMap(bool won)
    {
        if (won)
        {
            WG.FinishGame();
        }
    }
    public void resetLevel()
    {
        LoadMap(level);
    }

    public void LoadMap(int lev)
    {
        currentLevel = lev;
        level = lev;

        // Reset data
        //DeleteChilds(generatedWallFolder);
        //DeleteChilds(generatedEnemyFolder);
        //DeleteChilds(generatedBulletFolder);

        player1.SendMessage("ResetPosition");
        player1.GetComponent<Animator>().SetBool("hit", false);
        player1.SendMessage("SetShooting", false);
        player1.SendMessage("SetShooting", false);
        player1.SendMessage("SetShield", 6);



        // Enemy spawning reset
        spawnLocation.SendMessage("Reset");

        GenerateObjects();

        // powerUp reset
        powerUp.SendMessage("Reset");

        // play a sound
        levelStarting.Play();
        
    }

    private void DeleteChilds(Transform folder)
    {
        Transform[] ts = folder.GetComponentsInChildren<Transform>();

        foreach (var t in ts)
        {
            if (!t.gameObject.name.Contains("Generated"))
            {
                Destroy(t.gameObject);
            }
        }
    }

    public void GenerateObjects()
    {
        for (int i = 0; i < 35; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                Transform t = null;
                if (m[i][j] == 'o')
                {
                    t = Instantiate(wall, new Vector3(j - 11, 11 - (i + 1), 0), wall.rotation) as Transform;
                }
                else if (m[i][j] == 'Q')
                {
                    t = Instantiate(iron, new Vector3(j - 11, 11 - (i + 1), 0), wall.rotation) as Transform;
                }
                else if (m[i][j] == 'b')
                {
                    t = Instantiate(bush, new Vector3(j - 11, 11 - (i + 1), 0), wall.rotation) as Transform;
                }
                else if (m[i][j] == 'i')
                {
                    t = Instantiate(ice, new Vector3(j - 11, 11 - (i + 1), 0), wall.rotation) as Transform;
                }
                else if (m[i][j] == 'w')
                {
                    t = Instantiate(water, new Vector3(j - 11, 11 - (i + 1), 0), wall.rotation) as Transform;
                }
                if (m[i][j] != '.')
                {
                    t.parent = generatedWallFolder;
                }
            }
        }
        //gen.localPosition = new Vector2(0, 2);
    }
}

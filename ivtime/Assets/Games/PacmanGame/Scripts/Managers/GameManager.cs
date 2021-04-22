using UnityEngine;

public class GameManager : MonoBehaviour
{

    //--------------------------------------------------------
    // Game variables

    public static int Level = 0;
    public static int lives = 3;

    public enum GameState { Init, Game, Dead }
    public static GameState gameState;

    private GameObject pacman;
    private GameObject blinky;
    private GameObject pinky;
    private GameObject inky;
    private GameObject clyde;

    public static bool scared;

    public float scareLength;
    private float _timeToCalm;

    public float SpeedPerLevel;
    //-------------------------------------------------------------------
    // singleton implementation
    private static GameManager _instance;
    public WinGame _wingame;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    //-------------------------------------------------------------------
    // function definitions

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }

        AssignGhosts();
    }

    void Start()
    {
        gameState = GameState.Game;
    }

    void OnLevelWasLoaded()
    {
        if (Level == 0) lives = 3;

        Debug.Log("Level " + Level + " Loaded!");
        AssignGhosts();
        ResetVariables();


        // Adjust Ghost variables!
        clyde.GetComponent<GhostMove>().speed += Level * SpeedPerLevel;
        blinky.GetComponent<GhostMove>().speed += Level * SpeedPerLevel;
        pinky.GetComponent<GhostMove>().speed += Level * SpeedPerLevel;
        inky.GetComponent<GhostMove>().speed += Level * SpeedPerLevel;
        pacman.GetComponent<PlayerController>().speed += Level * SpeedPerLevel / 2;


    }

    private void ResetVariables()
    {
        _timeToCalm = 0.0f;
        scared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scared && _timeToCalm <= Time.time)
            CalmGhosts();
    }

    public void ResetScene()
    {
        CalmGhosts();

        pacman.transform.position = new Vector3(15f, 11f, 0f);
        blinky.transform.position = new Vector3(15f, 20f, 0f);
        pinky.transform.position = new Vector3(14.5f, 17f, 0f);
        inky.transform.position = new Vector3(16.5f, 17f, 0f);
        clyde.transform.position = new Vector3(12.5f, 17f, 0f);

        pacman.GetComponent<PlayerController>().ResetDestination();
        blinky.GetComponent<GhostMove>().InitializeGhost();
        pinky.GetComponent<GhostMove>().InitializeGhost();
        inky.GetComponent<GhostMove>().InitializeGhost();
        clyde.GetComponent<GhostMove>().InitializeGhost();

        gameState = GameState.Game;

    }

    public void ToggleScare()
    {
        if (!scared) ScareGhosts();
        else CalmGhosts();
    }

    public void ScareGhosts()
    {
        scared = true;
        blinky.GetComponent<GhostMove>().Frighten();
        pinky.GetComponent<GhostMove>().Frighten();
        inky.GetComponent<GhostMove>().Frighten();
        clyde.GetComponent<GhostMove>().Frighten();
        _timeToCalm = Time.time + scareLength;

        Debug.Log("Ghosts Scared");
    }

    public void CalmGhosts()
    {
        scared = false;
        blinky.GetComponent<GhostMove>().Calm();
        pinky.GetComponent<GhostMove>().Calm();
        inky.GetComponent<GhostMove>().Calm();
        clyde.GetComponent<GhostMove>().Calm();
    }

    void AssignGhosts()
    {
        // find and assign ghosts
        clyde = GameObject.Find("clyde");
        pinky = GameObject.Find("pinky");
        inky = GameObject.Find("inky");
        blinky = GameObject.Find("blinky");
        pacman = GameObject.Find("pacman");

        if (clyde == null || pinky == null || inky == null || blinky == null) Debug.Log("One of ghosts are NULL");
        if (pacman == null) Debug.Log("Pacman is NULL");

    }

    public void LoseLife()
    {
        lives--;
        gameState = GameState.Dead;
    }
    public void Win()
    {
        _wingame.FinishGame();
    }
}

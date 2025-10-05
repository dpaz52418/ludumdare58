using Unity.Profiling;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Overall scoring for the game. Public access. There was something said about "get" and "private set" but
    // if I don't need it then I dont need it
    public static ScoreManager Instance;
    public int acornScore = 0;

    // Overall meters ascended for the game. Public access
    public int metersAscended = 0;

    // I'm told this is good practice
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // this is to prevent duplicates
            Destroy(gameObject);
        }
    }

    public void addScore(int score)
    {
        acornScore += score;
        Debug.Log("Score: " + acornScore);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

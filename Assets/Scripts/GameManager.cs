using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton (global access)
    public static GameManager instance;

    [Header("Time Settings")]
    public float startTime = 120f;
    public float timeRemaining;
    private bool gameEnded = false;

    [Header("UI")]
    public ResultUI resultUI;
    public TimeUI timeUI;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        timeRemaining = startTime;
        Time.timeScale = 1;
    }

    void Update()
{
    timeRemaining -= Time.deltaTime;

    if (timeRemaining <= 0)
    {
        resultUI.ShowResult(false, 0);
        enabled = false;
    }
}

    // Called when player hits obstacle
    public void ReduceTime(float amount)
    {
        timeRemaining -= amount;
        if (timeRemaining < 0)
            timeRemaining = 0;
    }

    // Called when delivery is completed
   public void DeliveryComplete()
    {
        resultUI.ShowResult(true, timeRemaining);
    }

    void EndGame(bool success)
    {
        gameEnded = true;
        Time.timeScale = 0;
        resultUI.ShowResult(success, timeRemaining);
    }
}

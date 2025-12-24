using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton (global access)
    public static GameManager instance;

    public enum GameResult
    {
        None,
        Win,
        Lose
    }

    [Header("Persistent Game State")]
    public GameResult result = GameResult.None;
    public int score = 0;
    public string currentLevelSceneName = string.Empty;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Track active scene changes to remember last gameplay scene
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    // Remember the last non-GameOver scene as the current level
    private void OnActiveSceneChanged(Scene previous, Scene next)
    {
        if (next.name != "GameOver")
        {
            currentLevelSceneName = next.name;
        }
    }

    // Public API for reporting outcomes from gameplay
    public void ReportWin(int points)
    {
        result = GameResult.Win;
        score = points;
        LoadGameOverScene();
    }

    public void ReportLose(int points)
    {
        result = GameResult.Lose;
        score = points;
        LoadGameOverScene();
    }

    public void DeliveryComplete()
    {
        // Backward-compatible hook for existing calls
        // Default score: 10 points (example) — adjust if you have a scoring system
        ReportWin(score > 0 ? score : 10);
    }

    public void LoadGameOverScene()
    {
        Debug.Log($"Loading GameOver scene... Result: {result}, Score: {score}");
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }
}

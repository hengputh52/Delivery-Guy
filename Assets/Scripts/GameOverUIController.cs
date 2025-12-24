using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverUIController : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;
    public Button playAgainButton;
    public Button backToLevelButton;

    // Static variables set by gameplay scripts before loading GameOver
    public static bool isWin = false;
    public static int score = 0;
    public static string lastLevelName = "GameScene_level_1";

    void Awake()
    {
        // Wire up buttons if assigned
        if (playAgainButton != null)
            playAgainButton.onClick.AddListener(OnPlayAgain);
        if (backToLevelButton != null)
            backToLevelButton.onClick.AddListener(OnBackToLevel);
    }

    void OnEnable()
    {
        Debug.Log("GameOverUIController OnEnable called!");
        UpdateUI();
    }

    void UpdateUI()
    {
        string headline = isWin ? "YOU WIN!" : "YOU LOSE!";
        Debug.Log($"Setting result to: {headline}, score: {score}");

        if (resultText != null)
            resultText.text = headline;
        else
            Debug.LogError("resultText is NULL!");

        if (scoreText != null)
        {
            scoreText.text = $"{score} POINTS";
        }
        else
            Debug.LogError("scoreText is NULL!");
    }

    public void OnPlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lastLevelName);
    }

    public void OnBackToLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }
}

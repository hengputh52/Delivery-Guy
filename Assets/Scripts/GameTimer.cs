using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;
    private bool isRunning = true;

    public TextMeshProUGUI timeText;
    // Deprecated: ResultUI popup is replaced by GameOver scene

    void Start()
    {
        currentTime = startTime;
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;
            Debug.Log("Time Up! Loading GameOver...");
            GameOverUIController.isWin = false;
            GameOverUIController.score = 0;
            GameOverUIController.lastLevelName = SceneManager.GetActiveScene().name;
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = "Time: " + Mathf.Ceil(currentTime);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Call this when delivery is completed
    public void OnDeliveryComplete()
    {
        StopTimer();
        // Report win and load GameOver scene; example score uses remaining time rounded
        if (GameManager.instance != null)
        {
            int points = Mathf.RoundToInt(currentTime);
            GameManager.instance.ReportWin(points);
        }
    }
}

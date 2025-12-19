using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameTimer gameTimer;
    public AITruckController[] aiTrucks;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);

        // Automatically find all AITruckController instances in the scene
        aiTrucks = FindObjectsOfType<AITruckController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

        gameTimer.StopTimer();

        foreach (AITruckController ai in aiTrucks)
        {
            ai.PauseAI();
        }

        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

        gameTimer.ResumeTimer();

        foreach (AITruckController ai in aiTrucks)
        {
            ai.ResumeAI();
        }

        isPaused = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

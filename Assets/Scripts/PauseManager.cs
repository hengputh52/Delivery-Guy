using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameTimer gameTimer;
    public AITruckController[] aiTrucks;
    public MSVehicleControllerFree playerCar;

    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
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
        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;

        if (gameTimer != null)
            gameTimer.StopTimer();

        foreach (AITruckController ai in aiTrucks)
        {
            ai.PauseAI();
        }

        if (playerCar != null)
            playerCar.PauseCar();

        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;

        if (gameTimer != null)
            gameTimer.ResumeTimer();

        foreach (AITruckController ai in aiTrucks)
        {
            ai.ResumeAI();
        }

        if (playerCar != null)
            playerCar.ResumeCar();

        isPaused = false;
    }

    public void BackToLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }
}

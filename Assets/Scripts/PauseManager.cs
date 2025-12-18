using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Start()
    {
        Debug.Log("PauseManager started!");
        
        // Make sure pause panel is hidden at start
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Pause Panel not assigned! Drag it in the Inspector.");
        }
    }

    void Update()
    {
        // Also allow ESC key to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        Debug.Log("TogglePause called! isPaused: " + isPaused);
        
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused!");
        
        if (pausePanel != null)
            pausePanel.SetActive(true);
            
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed!");
        
        if (pausePanel != null)
            pausePanel.SetActive(false);
            
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BackToMenu()
    {
        Debug.Log("Returning to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

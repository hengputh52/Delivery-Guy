using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene (change "Demo" to your level scene name)
        SceneManager.LoadScene("Demo");
    }

    public void OpenSettings()
    {
        // You can open a settings panel here
        Debug.Log("Settings clicked");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        
        // This line is for testing in the Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
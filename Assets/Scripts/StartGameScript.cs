using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the LevelMenu scene as requested
        SceneManager.LoadScene("GameScene_Level_1");
    }
}

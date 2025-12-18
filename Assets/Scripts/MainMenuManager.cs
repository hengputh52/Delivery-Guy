using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //public string GameSceneLevel1 = 'Game Scene'
    public void StartGame()
    {
        Debug.Log("Loading Level Menu...");
        SceneManager.LoadScene("Game Scene_level_1");
    }
}

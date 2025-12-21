using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    // Assign these in the Inspector or use the default names
    public string level1SceneName = "GameScene_Level_1";
    public string level2SceneName = "GameScene_Level_2";
    //public string level3SceneName = "GameScene_Level_3";

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2SceneName);
    }

    // public void LoadLevel3()
    // {
    //     SceneManager.LoadScene(level3SceneName);
    // }
}
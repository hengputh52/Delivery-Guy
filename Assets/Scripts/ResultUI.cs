using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI timeText;

    public void ShowResult(bool success, float timeLeft)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        titleText.text = success ? "DELIVERY SUCCESS!" : "DELIVERY FAILED : Time is Up";
        timeText.text = "Time Left: " + Mathf.Round(timeLeft);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}

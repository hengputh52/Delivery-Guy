using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;

    public TextMeshProUGUI timeText;

    void Start()
    {
        currentTime = startTime;
        UpdateUI();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
    }

    void GameOver()
    {
        Debug.Log("Time Up!");
        //SceneManager.LoadScene("GameOverScene");
    }

    public void StopTimer()
    {
        enabled = false;
    }
}

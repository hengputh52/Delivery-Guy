using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;
    private bool isRunning = true;

    public TextMeshProUGUI timeText;

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
            Debug.Log("Time Up!");
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
}

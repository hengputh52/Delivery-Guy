using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;
    private bool isRunning = true;

    public TextMeshProUGUI timeText;
    public ResultUI resultUI; // Assign in Inspector

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
            if (resultUI != null)
                resultUI.ShowResult(false, 0); // Show failed result
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

    // Call this when delivery is completed
    public void OnDeliveryComplete()
    {
        if (resultUI != null)
            resultUI.ShowResult(true, currentTime); // Show success result
        StopTimer();
    }
}

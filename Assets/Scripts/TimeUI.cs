using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public void UpdateTime(float time)
    {
        time = Mathf.Max(time, 0);
        timeText.text = "Time: " + Mathf.Ceil(time);
    }
}

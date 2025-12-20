using UnityEngine;
using TMPro;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    public TextMeshProUGUI instructionText;
    public GameTimer gameTimer; // Assign in Inspector

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        instructionText.text = "Deliver the package to the target!";
    }

    public void CompleteDelivery()
    {
        instructionText.text = "Delivery Completed!";
        if (gameTimer != null)
            gameTimer.OnDeliveryComplete();
    }
}

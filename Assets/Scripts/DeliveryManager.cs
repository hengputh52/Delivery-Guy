using UnityEngine;
using TMPro;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    [Header("UI")]
    public TextMeshProUGUI instructionText;

    [Header("Systems")]
    public GameTimer gameTimer; // Assign in Inspector

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Debug.Log("Start game is called");
        //SetNormalInstruction();
        
        instructionText.text = "Deliver the package to the target!";

    }

    // =========================
    // INSTRUCTION STATES
    // =========================

    public void SetNormalInstruction()
    {
        instructionText.text = "Deliver the package to the target!";
        //instructionText.color = Color.white;
    }

    public void SetPoliceChaseInstruction()
    {
        instructionText.text = "POLICE CHASING YOU! DELIVER FAST!";
        //instructionText.color = Color.red;
    }

    public void SetLoseInstruction()
    {
        instructionText.text = "YOU WERE CAUGHT BY POLICE";
        //instructionText.color = Color.red;
    }

    public void SetWinInstruction()
    {
        instructionText.text = "DELIVERY COMPLETED!";
        //instructionText.color = Color.green;
    }

    // =========================
    // DELIVERY LOGIC
    // =========================

    public void CompleteDelivery()
    {
        SetWinInstruction();

        if (gameTimer != null)
            gameTimer.OnDeliveryComplete();
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PoliceManager : MonoBehaviour
{
    public static PoliceManager Instance;

    [Header("Police")]
    public PoliceFollow[] policeCars;
    public Transform player;

    [Header("Catch Settings")]
    public float catchDistance = 2f;
    public float catchTime = 3f;

    [Header("UI")]
    public TextMeshProUGUI policeWarningText;

    private bool chaseActive = false;
    private float catchTimer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        policeWarningText.gameObject.SetActive(false);

        foreach (var police in policeCars)
            police.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!chaseActive) return;

        bool policeClose = false;

        foreach (var police in policeCars)
        {
            float dist = Vector3.Distance(police.transform.position, player.position);
            Debug.Log($"Police distance to player: {dist:F2}, catchDistance: {catchDistance}");

            if (dist <= catchDistance)
            {
                policeClose = true;
                break;
            }
        }

        if (policeClose)
        {
            catchTimer += Time.deltaTime;
            Debug.Log($"Police close! Catch timer: {catchTimer:F2}/{catchTime}");

            if (catchTimer >= catchTime)
            {
                Debug.Log("CATCH TIME REACHED! Calling PlayerCaught()");
                PlayerCaught();
            }
        }
        else
        {
            if (catchTimer > 0)
                Debug.Log("Police too far, resetting catch timer");
            catchTimer = 0f;
        }
    }

    public void StartChase()
    {
        if (chaseActive) return;

        Debug.Log("StartChase called! Activating police...");
        chaseActive = true;
        policeWarningText.gameObject.SetActive(true);

        foreach (var police in policeCars)
        {
            police.gameObject.SetActive(true);
            police.StartChase(player);
            Debug.Log($"Police {police.gameObject.name} activated and chasing");
        }

        DeliveryManager.Instance?.SetPoliceChaseInstruction();
    }

    void PlayerCaught()
    {
        Debug.Log("===== PLAYER CAUGHT! =====");
        Debug.Log("Setting GameOver state...");

        policeWarningText.text = "YOU WERE CAUGHT!";
        DeliveryManager.Instance?.SetLoseInstruction();

        // Ensure this only triggers once
        chaseActive = false;

        // Set GameOver state and load scene
        GameOverUIController.isWin = false;
        GameOverUIController.score = 0;
        GameOverUIController.lastLevelName = SceneManager.GetActiveScene().name;

        Debug.Log($"isWin: {GameOverUIController.isWin}");
        Debug.Log($"score: {GameOverUIController.score}");
        Debug.Log($"lastLevelName: {GameOverUIController.lastLevelName}");
        Debug.Log("Loading GameOver scene...");

        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");

        Debug.Log("LoadScene called!");
    }
}

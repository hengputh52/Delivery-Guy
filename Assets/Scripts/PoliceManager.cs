using UnityEngine;
using TMPro;

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
            if (dist <= catchDistance)
            {
                policeClose = true;
                break;
            }
        }

        if (policeClose)
        {
            catchTimer += Time.deltaTime;

            if (catchTimer >= catchTime)
                PlayerCaught();
        }
        else
        {
            catchTimer = 0f;
        }
    }

    public void StartChase()
    {
        if (chaseActive) return;

        chaseActive = true;
        policeWarningText.gameObject.SetActive(true);

        foreach (var police in policeCars)
        {
            police.gameObject.SetActive(true);
            police.StartChase(player);
        }

        DeliveryManager.Instance?.SetPoliceChaseInstruction();
    }

    void PlayerCaught()
    {
        Time.timeScale = 0f;
        policeWarningText.text = "YOU WERE CAUGHT!";

        DeliveryManager.Instance?.SetLoseInstruction();
    }
}

using UnityEngine;

public class PoliceManager : MonoBehaviour
{
    public static PoliceManager Instance;

    public PoliceFollow policeCar;
    public Transform player;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartChase()
    {
        if (policeCar == null || player == null) return;

        policeCar.gameObject.SetActive(true);
        policeCar.StartChase(player);

        Debug.Log("Police chase started!");
    }
}

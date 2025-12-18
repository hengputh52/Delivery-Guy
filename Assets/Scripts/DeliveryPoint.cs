using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryPoint : MonoBehaviour
{
    private bool delivered = false;
    public GameObject deliveryIcon;
    public GameObject distanceTextObject;

    void Start()
    {
        Debug.Log("DeliveryPoint script is active on: " + gameObject.name);
    }

   private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called by: " + other.gameObject.name + " Tag: " + other.tag);
        
        if (delivered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached delivery point!");
            delivered = true;
            if (deliveryIcon != null)
                deliveryIcon.SetActive(false);

            Deliver();
        }
    }
    void Deliver()
    {
        Debug.Log("Package Delivered!");

        if (distanceTextObject != null)
            distanceTextObject.SetActive(false);

        if (DeliveryManager.Instance != null)
            DeliveryManager.Instance.CompleteDelivery();

        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
            timer.StopTimer();

        SceneManager.LoadScene("WinScene");
    }
}

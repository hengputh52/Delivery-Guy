using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            Debug.Log("Player hit AI car!");

            if (PoliceManager.Instance != null)
            {
                PoliceManager.Instance.StartChase();
            }
        }
    }
}

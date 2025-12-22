using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            PoliceManager.Instance?.StartChase();
        }
    }
}

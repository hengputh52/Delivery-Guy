using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float penaltyTime = 3f;
    private float lastHitTime;
    public float hitCooldown = 1f;

    public AudioSource crashSound;

    void OnCollisionEnter(Collision collision)
    {
        if (Time.time - lastHitTime < hitCooldown)
            return;

        if (collision.gameObject.CompareTag("Obstacle") )
        {
            lastHitTime = Time.time;

            GameManager.instance.ReduceTime(penaltyTime);

            if (crashSound != null)
                crashSound.Play();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lastHitTime = Time.time;

            // Obstacle hit - lose
            lastHitTime = Time.time;

            GameOverUIController.isWin = false;
            GameOverUIController.score = 0;
            GameOverUIController.lastLevelName = SceneManager.GetActiveScene().name;
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");

            if (crashSound != null)
                crashSound.Play();
        }
    }
}

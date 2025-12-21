using UnityEngine;

public class PoliceFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 12f;
    public float rotationSpeed = 5f;
    public float stopDistance = 2.5f;

    private bool isChasing = false;

    void Update()
    {
        if (!isChasing || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Move toward player
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;

            transform.position += direction * speed * Time.deltaTime;

            // Rotate toward player
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            // Player caught
            Debug.Log("Player caught by police!");
            Time.timeScale = 0f;
        }
    }

    public void StartChase(Transform target)
    {
        player = target;
        isChasing = true;
    }

    public void StopChase()
    {
        isChasing = false;
    }
}

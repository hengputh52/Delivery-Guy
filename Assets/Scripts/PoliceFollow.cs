using UnityEngine;

public class PoliceFollow : MonoBehaviour
{
    private Transform player;
    public float speed = 0.001f;
    public float rotationSpeed = 3f;
    public float stopDistance = 2.5f;

    private bool isChasing = false;
    private Rigidbody rb;
    private Vector3 targetDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (!isChasing || player == null) 
        {
            targetDirection = Vector3.zero;
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Calculate direction toward player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            directionToPlayer.y = 0;

            if (directionToPlayer.magnitude > 0.01f)
            {
                targetDirection = directionToPlayer;
            }
        }
        else
        {
            targetDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (!isChasing || targetDirection.magnitude < 0.01f) return;

        // Move the transform
        Vector3 newPosition = transform.position + (targetDirection * speed * Time.fixedDeltaTime);
        transform.position = newPosition;

        // Rotate to face movement direction
        if (targetDirection.magnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.fixedDeltaTime
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
        if (target == null)
        {
            Debug.LogError("PoliceFollow: Target is null!");
            return;
        }
        
        player = target;
        isChasing = true;
        
        #if UNITY_EDITOR
        Debug.Log($"Police car {gameObject.name} started chasing!");
        #endif
    }

    public void StopChase()
    {
        isChasing = false;
        targetDirection = Vector3.zero;
    }
}

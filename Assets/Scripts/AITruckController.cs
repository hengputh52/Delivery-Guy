using UnityEngine;

public class AITruckController : MonoBehaviour
{
    [Header("Waypoint Settings")]
    public Transform waypointParent;
    public Transform[] waypoints;

    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float turnSpeed = 3f;
    public float waypointReachDistance = 3f;

    [Header("Truck Settings")]
    public float accelerationRate = 2f;
    public float turnSlowdownFactor = 0.5f;

    private int currentWaypointIndex = 0;
    private Rigidbody rb;
    private float currentSpeed = 0f;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (waypointParent != null && (waypoints == null || waypoints.Length == 0))
        {
            CollectWaypointsFromParent();
        }
    }

    void FixedUpdate()
    {
        if (isPaused) return;
        if (waypoints == null || waypoints.Length == 0) return;

        DriveToWaypoint();
    }

    void CollectWaypointsFromParent()
    {
        int childCount = waypointParent.childCount;
        waypoints = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    void DriveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;

        float angleToTarget = Vector3.Angle(transform.forward, direction);
        float turnMultiplier = 1f - (angleToTarget / 180f) * turnSlowdownFactor;

        float targetSpeed = moveSpeed * turnMultiplier;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, accelerationRate * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + transform.forward * currentSpeed * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));
        }

        if (Vector3.Distance(transform.position, target.position) < waypointReachDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // 🔴 PAUSE CONTROL
    public void PauseAI()
    {
        isPaused = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ResumeAI()
    {
        isPaused = false;
    }

    void OnDrawGizmos()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.cyan;
        foreach (Transform wp in waypoints)
        {
            if (wp != null)
                Gizmos.DrawSphere(wp.position, 0.5f);
        }
    }
}

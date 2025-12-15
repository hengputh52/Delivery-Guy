using UnityEngine;

public class AICarController : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 10f;
    public float turnSpeed = 5f;
    public float waypointReachDistance = 2f;

    private int currentWaypointIndex = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        DriveToWaypoint();
    }

    void DriveToWaypoint()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        // Move forward
        Vector3 forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Rotate toward waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));

        // Check if reached waypoint
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < waypointReachDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0; // loop path
        }
    }

    void OnDrawGizmos()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.yellow;
        foreach (Transform wp in waypoints)
        {
            if (wp != null)
                Gizmos.DrawSphere(wp.position, 0.3f);
        }
    }
}

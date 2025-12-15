using UnityEngine;

public class AITruckController : MonoBehaviour
{
    [Header("Waypoint Settings")]
    [Tooltip("Assign the WayTruck parent object here, or assign waypoints manually")]
    public Transform waypointParent;
    public Transform[] waypoints;
    
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float turnSpeed = 3f;
    public float waypointReachDistance = 3f;
    
    [Header("Truck Settings")]
    [Tooltip("Trucks are heavier and slower to accelerate")]
    public float accelerationRate = 2f;
    [Tooltip("How much the truck slows down when turning")]
    public float turnSlowdownFactor = 0.5f;
    
    private int currentWaypointIndex = 0;
    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Auto-find waypoints from parent if assigned
        if (waypointParent != null && (waypoints == null || waypoints.Length == 0))
        {
            CollectWaypointsFromParent();
        }
    }
    
    void CollectWaypointsFromParent()
    {
        // Get all child transforms as waypoints
        int childCount = waypointParent.childCount;
        waypoints = new Transform[childCount];
        
        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
        
        Debug.Log($"AITruckController: Found {waypoints.Length} waypoints from {waypointParent.name}");
    }

    void FixedUpdate()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        
        DriveToWaypoint();
    }

    void DriveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        if (target == null) return;
        
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0; // Keep movement horizontal
        
        // Calculate angle to target for turn slowdown
        float angleToTarget = Vector3.Angle(transform.forward, direction);
        float turnMultiplier = 1f - (angleToTarget / 180f) * turnSlowdownFactor;
        
        // Smoothly accelerate/decelerate (trucks are slower)
        float targetSpeed = moveSpeed * turnMultiplier;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, accelerationRate * Time.fixedDeltaTime);
        
        // Move forward
        Vector3 forwardMove = transform.forward * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Rotate toward waypoint (trucks turn slower)
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));
        }

        // Check if reached waypoint
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < waypointReachDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Loop path
            }
        }
    }
    
    // Public method to set waypoints from code
    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        currentWaypointIndex = 0;
    }
    
    // Public method to set waypoint parent
    public void SetWaypointParent(Transform parent)
    {
        waypointParent = parent;
        CollectWaypointsFromParent();
        currentWaypointIndex = 0;
    }

    void OnDrawGizmos()
    {
        if (waypoints == null) return;

        // Draw waypoints in different color for truck
        Gizmos.color = Color.cyan;
        foreach (Transform wp in waypoints)
        {
            if (wp != null)
                Gizmos.DrawSphere(wp.position, 0.5f);
        }
        
        // Draw path lines
        Gizmos.color = Color.blue;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] != null)
            {
                int nextIndex = (i + 1) % waypoints.Length;
                if (waypoints[nextIndex] != null)
                {
                    Gizmos.DrawLine(waypoints[i].position, waypoints[nextIndex].position);
                }
            }
        }
    }
}
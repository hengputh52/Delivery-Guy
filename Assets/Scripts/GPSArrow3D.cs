using UnityEngine;

public class GPSArrow3D : MonoBehaviour
{
    public Transform player;          // Player car
    public Transform deliveryTarget;  // Delivery point

    private Quaternion initialRotation;

    void Start()
    {
        // Save prefab rotation (X=-80, Y=-180, Z=-90)
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (!player || !deliveryTarget) return;

        // 1️⃣ Direction in WORLD space
        Vector3 worldDirection = deliveryTarget.position - player.position;
        worldDirection.y = 0f;

        if (worldDirection.sqrMagnitude < 0.01f) return;

        // 2️⃣ Convert WORLD direction to PLAYER LOCAL space
        Vector3 localDirection = player.InverseTransformDirection(worldDirection);

        // 3️⃣ Calculate angle from LOCAL direction
        float angle = Mathf.Atan2(localDirection.x, localDirection.z) * Mathf.Rad2Deg;

        // 4️⃣ Rotate arrow relative to car
        Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);

        // 5️⃣ Apply prefab rotation offset
        transform.localRotation = targetRotation * initialRotation;
    }
}

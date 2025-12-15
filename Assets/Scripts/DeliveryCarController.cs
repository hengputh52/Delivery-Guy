using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCarController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float turnSpeed = 80f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation on X and Z to prevent flipping
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Turn()
    {
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
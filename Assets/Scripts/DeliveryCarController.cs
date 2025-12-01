using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCarController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float turnSpeed = 80f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Vertical");  // W/S or Up/Down Arrow
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
    void Turn()
    {
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

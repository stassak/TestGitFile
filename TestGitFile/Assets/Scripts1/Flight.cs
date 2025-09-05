using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement")]
    [SerializeField] private float thrustPower = 50f;
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float strafePower = 15f;

    [Header("Rotation")]
    [SerializeField] private float pitchSpeed = 60f;   // Up/Down
    [SerializeField] private float yawSpeed = 60f;     // Left/Right
    [SerializeField] private float rollSpeed = 80f;    // Tilt

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // space shuttle, no gravity
        rb.drag = 0.1f;
        rb.angularDrag = 0.1f;
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        // Forward / backward thrust
        float thrust = Input.GetAxis("Vertical") * thrustPower;

        // Boost with LeftShift
        if (Input.GetKey(KeyCode.LeftShift))
            thrust *= boostMultiplier;

        // Strafe left/right with Q/E or A/D
        float strafe = Input.GetAxis("Horizontal") * strafePower;

        // Apply forces
        rb.AddForce(transform.forward * thrust);
        rb.AddForce(transform.right * strafe);
    }

    void HandleRotation()
    {
        // Pitch (W/S or Up/Down arrows)
        float pitch = -Input.GetAxis("Vertical") * pitchSpeed;

        // Yaw (A/D or Left/Right arrows)
        float yaw = Input.GetAxis("Horizontal") * yawSpeed;

        // Roll (Q/E keys)
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = rollSpeed;
        if (Input.GetKey(KeyCode.E)) roll = -rollSpeed;

        // Combine rotations
        Vector3 torque = new Vector3(pitch, yaw, roll);
        rb.AddRelativeTorque(torque);
    }
}

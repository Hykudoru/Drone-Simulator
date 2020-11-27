using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody drone;
    DroneInput input;
    [SerializeField] [Range(1, 60f)] float maxDegPitchRoll = 28f;
    [SerializeField] float rollPitchSpeed = 50f;
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float throttleSpeed = 50f;
    [SerializeField] float yawTurnSpeed = 360f;
    float roll;
    float pitch;
    float yaw;
    Vector3 move = Vector3.zero;
    Vector3 throttle = Vector3.zero;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
        input = new DroneInput();
    }

    private void OnEnable()
    {
        input.Drone.Enable();
    }

    private void OnDisable()
    {
        input.Drone.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = input.Drone.Move.ReadValue<Vector2>();
        float throtteInput = input.Drone.Throttle.ReadValue<float>();
        float yawInput = input.Drone.Rotate.ReadValue<float>();

        move = (drone.transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;
        move.y = 0;
        throttle = drone.transform.up * throtteInput * throttleSpeed;

        roll = move.x * maxDegPitchRoll;// rollPitchSpeed;
        pitch = move.z * maxDegPitchRoll;// rollPitchSpeed;
        yaw = yawInput * yawTurnSpeed;
    }

    private void FixedUpdate()
    {
        // roll/pitch/yaw
        //var rotAxis = Vector3.Cross(drone.transform.up, move);
        //drone.transform.localRotation = Quaternion.AngleAxis(rotate, Vector3.up) * Quaternion.AngleAxis(maxDegPitchRoll, rotAxis);
        //drone.angularVelocity = Vector3.up * yaw * Time.deltaTime;

        // cancel gravity
        if (drone.useGravity)
        {
            drone.velocity += -Physics.gravity * Time.deltaTime;
        }

        //move up/down/left/right/forward/back
        drone.velocity += move * Time.deltaTime;
        drone.velocity += throttle * Time.deltaTime;

    }
}

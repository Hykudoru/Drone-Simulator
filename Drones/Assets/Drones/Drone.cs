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

        roll = moveInput.x * maxDegPitchRoll;// rollPitchSpeed;
        pitch = moveInput.y * maxDegPitchRoll;// rollPitchSpeed;
        yaw = yawInput * yawTurnSpeed;
    }

    float rotation;

    private void FixedUpdate()
    {/*
        rotation += new Vector3(pitch, yaw, roll) * Time.deltaTime;
        rotation.x = Mathf.Clamp(rotation.x, -maxDegPitchRoll, maxDegPitchRoll);
        rotation.z = Mathf.Clamp(rotation.z, -maxDegPitchRoll, maxDegPitchRoll);
        drone.transform.localRotation = Quaternion.Euler(rotation);
        */
        //drone.transform.localRotation = Quaternion.Slerp(drone.transform.localRotation,  targetRot, rollPitchSpeed * Time.deltaTime);
        //drone.transform.localRotation *= Quaternion.Euler(Vector3.up * yaw * Time.deltaTime);

        // roll/pitch/yaw
        //var rotAxis = Vector3.Cross(drone.transform.up, move);
        //drone.transform.localRotation = Quaternion.Euler(rotation) *Quaternion.AngleAxis(maxDegPitchRoll, rotAxis);
        //drone.angularVelocity = Vector3.up * yaw * Time.deltaTime;


        // roll/pitch/yaw
        var targetRotation = Quaternion.AngleAxis(yaw*Time.deltaTime, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);

        drone.transform.localRotation = Quaternion.Slerp(drone.transform.rotation, targetRotation, 20 * Time.deltaTime);

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

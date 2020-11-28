using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody drone;
    DroneInput input;
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float throttleSpeed = 50f;
    [SerializeField] float yawSpeed = 360f;
    [SerializeField] float tiltSpeed = 50f;
    [SerializeField] [Range(1, 60f)] float maxRollDeg = 28f;
    [SerializeField] [Range(1, 60f)] float maxPitchDeg = 28f;
    [SerializeField] [Range(1, 60f)] float maxTiltDeg = 28f;
    [SerializeField] float maxAltitude = Mathf.Infinity;
    [SerializeField] float maxDisplacement = Mathf.Infinity;
    
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

    Vector2 moveInput;
    float throttleInput;
    float yawInput;

    private void Update()
    {
        moveInput = input.Drone.Move.ReadValue<Vector2>();
        throttleInput = input.Drone.Throttle.ReadValue<float>();
        yawInput = input.Drone.Rotate.ReadValue<float>();

        move = (drone.transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;
        move.y = 0;
        throttle = drone.transform.up * throttleInput * throttleSpeed;
        
        yaw += yawInput;
        roll = moveInput.x * maxRollDeg;
        pitch = moveInput.y * maxPitchDeg;
                                          
    }
    private void FixedUpdate()
    {
        // roll/pitch/yaw
        var targetRotation = Quaternion.AngleAxis(yaw*yawSpeed*Time.deltaTime, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);

        drone.transform.localRotation = targetRotation;//Quaternion.Slerp(drone.transform.localRotation, targetRotation, 20 * Time.deltaTime);

        // cancel gravity
        if (drone.useGravity)
        {
            drone.velocity += -Physics.gravity * Time.deltaTime;
        }

        //move up/down/left/right/forward/back
        drone.velocity += move * Time.deltaTime;
        drone.velocity += throttle * Time.deltaTime;
    }

    private void LateUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, drone.transform.TransformDirection(10f, 0f, 0f));
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, drone.transform.TransformDirection(0, 0, 10f));

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, drone.transform.TransformDirection(moveInput.x, 0, moveInput.y)*200);
        Gizmos.color = Color.gray;
        Gizmos.DrawRay(transform.position, drone.transform.TransformDirection(move));
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, move);
    }
}

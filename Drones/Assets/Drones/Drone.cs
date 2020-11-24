using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody drone;
    DroneInput controls;
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] float turnSpeed = 360f;
    [SerializeField] float throttleSpeed = 100f;
    
    [SerializeField] float maxRollPitch = 28f;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
        controls = new DroneInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        var directionInput = controls.Drone.Move.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
        var throttleInput = controls.Drone.Throttle.ReadValue<float>() * throttleSpeed * Time.deltaTime;
        var rotateInput = controls.Drone.Rotate.ReadValue<float>() * turnSpeed * Time.deltaTime;

        this.AddThrust(directionInput, throttleInput, rotateInput);
    }
    

    Vector3 thrust;
    float yaw;
    float roll;
    float pitch;
    Quaternion targetRotation = Quaternion.identity;
    
    private void FixedUpdate()
    {
        
        drone.rotation = Quaternion.Slerp(drone.transform.localRotation, targetRotation, Time.deltaTime*10);

        //move up/down/left/right/forward/back
        drone.velocity += thrust;
    }
    
    public void AddThrust(Vector2 move, float throttle, float rotate)
    {
        thrust = (drone.transform.right * move.x + drone.transform.forward * move.y);
        thrust.y = 0;
        thrust += drone.transform.up * throttle;
        
        yaw += rotate;
        move.Normalize();
        roll = move.x * maxRollPitch;
        pitch = move.y * maxRollPitch;
        // roll/pitch/yaw
        targetRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);
    }
} 
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
    [SerializeField] float maxSpeed = 100f;

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
        var directionInput = controls.Drone.Move.ReadValue<Vector2>() * moveSpeed;
        var throttleInput = controls.Drone.Throttle.ReadValue<float>() * throttleSpeed;
        var rotateInput = controls.Drone.Rotate.ReadValue<float>() * turnSpeed;

        this.AddThrust(directionInput, throttleInput, rotateInput);
    }
    










    Vector3 thrust;
    float yaw;
    float roll;
    float pitch;

    private void FixedUpdate()
    {
        this.Fly();
    }

    void Fly()
    {
        //drone.transform.rotation = Quaternion.Slerp(drone.rotation, Quaternion.Euler(0f, 0f, 0f), 100);

        // roll/pitch/yaw
        drone.transform.localRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);


        //move up/down/left/right/forward/back
        drone.velocity += thrust * Time.deltaTime;
    }
    
    public void AddThrust(Vector2 velocity, float throttle, float rotate)
    {
        thrust = (drone.transform.right * velocity.x + drone.transform.forward * velocity.y);
        thrust.y = 0;
        thrust += drone.transform.up * throttle;
        yaw += rotate * Time.deltaTime;
        velocity.Normalize();
        roll = velocity.x * maxRollPitch;
        pitch = velocity.y * maxRollPitch;
    }
} 
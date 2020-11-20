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
    [SerializeField] [Range(1, 60f)] float deg = 28f;
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float turnSpeed = 360f;
    [SerializeField] float throttleSpeed = 100f;
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
        // Vector2 moveInput = controls.Drone.Move.ReadValue<Vector2>().normalized;// Move left/right/horizontal axis + back/forward/longitudinal axis  

      //  float turn = yaw = controls.Drone.Yaw.ReadValue<float>();// turn/rotate/yaw

        Vector3 move;
        move.y = throttle = controls.Drone.Throttle.ReadValue<float>(); // up/down/vertical axis
        move.z = pitch = controls.Drone.Pitch.ReadValue<float>();// 
        move.x = roll = controls.Drone.Roll.ReadValue<float>();// 

        move.Normalize();
        move.x *= moveSpeed;
        move.z *= moveSpeed;
        move.y *= throttleSpeed;

        this.Thrust((move*Time.deltaTime), (controls.Drone.Yaw.ReadValue<float>() * turnSpeed * Time.deltaTime));
    }

    private void LateUpdate()
    {
        //test
        // Vector2.ClampMagnitude(move, 10f);
        Debug.Log(drone.velocity.magnitude);
    }







    float throttle;
    float roll;
    float pitch;
    float yaw;
    Vector3 move;

    
    
    private void FixedUpdate()
    {
        Fly();
    }
    
    void Thrust(Vector3 axes, float turn)
    {
        move = (drone.transform.up * axes.y + drone.transform.right * axes.x + drone.transform.forward * axes.z);
        yaw += turn;
    }

    public void Fly()
    {
        // roll/pitch/yaw
        drone.transform.localRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);

        //move up/down/left/right/forward/back
        drone.velocity += move;
    }
}

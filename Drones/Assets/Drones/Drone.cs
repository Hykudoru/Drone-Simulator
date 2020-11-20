﻿using System.Collections;
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

    float throttle;
    float roll;
    float pitch;
    float yaw;

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
    /*
    // Update is called once per frame
    void Update()
    {
        angularVelocity.y = Input.GetAxis("Horizontal") * turnSpeed;
        velocity.y = Input.GetAxis("Vertical");

        move = (transform.right * Input.GetAxis("Horizontal-2")+transform.forward * Input.GetAxis("Vertical-2"));
    }

    private void FixedUpdate()
    {
        drone.velocity += (velocity * thrust + move* moveSpeed)*Time.deltaTime;
        drone.angularVelocity = angularVelocity;
    }*/

    private void Update()
    {
        // Vector2 moveInput = controls.Drone.Move.ReadValue<Vector2>().normalized;// Move left/right/horizontal axis + back/forward/longitudinal axis  
        
        //yaw = controls.Drone.Yaw.ReadValue<float>();// turn/rotate/yaw
        
        Vector3 m;
        m.y = throttle = controls.Drone.Throttle.ReadValue<float>(); // up/down/vertical axis
        m.z = pitch = controls.Drone.Pitch.ReadValue<float>();// 
        m.x = roll = controls.Drone.Roll.ReadValue<float>();// 

        Move(m*moveSpeed *Time.deltaTime);
        Look(controls.Drone.Yaw.ReadValue<float>() * turnSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //test
       // Vector2.ClampMagnitude(move, 10f);
    }

    Vector3 move;
    
    private void FixedUpdate()
    {
        Fly();
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
    public void Move(Vector3 axes)
    {
        move = (drone.transform.up * axes.y + drone.transform.right * axes.x + drone.transform.forward * axes.z);
    }

    public void Look(float delta)
    {
        yaw += delta;
    }
}

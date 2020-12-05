﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody drone;
    DroneInput input;
    Animator animator;
    [SerializeField] float moveSpeed = 70f;
    [SerializeField] float throttleSpeed = 50f;
    [SerializeField] float yawSpeed = 360f;
    [SerializeField] float tiltSpeed = 20f;
    [SerializeField] [Range(10, 60f)] float maxRollDeg = 28f;
    [SerializeField] [Range(10, 60f)] float maxPitchDeg = 28f;
    [SerializeField] [Range(10, 60f)] float maxTiltDeg = 28f;
    [SerializeField] bool counterGravity = true;
    
    float roll;
    float pitch;
    float yaw;
    Vector2 moveInput;
    float throttleInput;
    float yawInput;
    
    Vector3 move = Vector3.zero;
    Vector3 throttle = Vector3.zero;

    Vector3 thrust;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
        input = new DroneInput();
        animator = GetComponent<Animator>();
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
        moveInput = input.Drone.Move.ReadValue<Vector2>();
        throttleInput = input.Drone.Throttle.ReadValue<float>();
        yawInput = input.Drone.Rotate.ReadValue<float>();

        yaw += yawInput * yawSpeed * Time.deltaTime;
        roll = moveInput.x * maxRollDeg;
        pitch = moveInput.y * maxPitchDeg;

        move = (drone.transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;
        move.y = 0;
        throttle = drone.transform.up * throttleInput * throttleSpeed;

        thrust = move + throttle;
        // cancel gravity
        if (counterGravity && drone.useGravity)
        {
            thrust += -Physics.gravity;// * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    { 
        // roll/pitch/yaw
        Quaternion targetRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);
        drone.transform.localRotation = Quaternion.Slerp(drone.transform.localRotation, targetRotation, tiltSpeed * Time.deltaTime);

        //move up/down/left/right/forward/back
        drone.velocity += thrust * Time.deltaTime;
    }

    private void LateUpdate()
    {
        float propellerSpeed = Mathf.Clamp(thrust.sqrMagnitude, 0f, 10f);
        animator.SetFloat("Thrust", propellerSpeed);
    }
}

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
    float throttle;
    float roll;
    float pitch;
    float yaw;
    Vector3 verticalThrust;
    Vector3 horizontalThrust;
    //Vector3 angularVelocity;

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


    float maxSpeed = 100f;
    private void Update()
    {
        Vector3 inputMove = controls.Drone.Move.ReadValue<Vector2>().normalized;
        float inputLook = controls.Drone.Look.ReadValue<float>();
        roll = inputMove.x * deg;
        pitch = inputMove.y * deg;

        Move((new Vector3(inputMove.x, 0f, inputMove.y) * moveSpeed) * Time.deltaTime);
        Turn(inputLook * turnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Fly();
    }










    Vector3 move;
    public void Move(Vector3 axes)
    {
        move = (drone.transform.up * axes.y + drone.transform.right * axes.x + drone.transform.forward * axes.z);
        //drone.velocity += v;
    }

    public void Turn(float delta)
    {
        yaw += delta;
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

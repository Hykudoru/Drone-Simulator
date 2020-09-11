using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody drone;
    [SerializeField] [Range(1, 60f)] float deg = 28f;
    [SerializeField] float thrust = 50f;
    [SerializeField] float turnSpeed = 360f;
    float roll;
    float pitch;
    float yaw;
    Vector3 verticalThrust;
    Vector3 horizontalThrust;
    //Vector3 angularVelocity;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
        if (drone.drag < 1)
        {
            drone.drag = 1;
        }
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
        yaw += Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        roll = Input.GetAxis("Horizontal-2") * deg;
        pitch = Input.GetAxis("Vertical-2") * deg;

        verticalThrust = drone.transform.up * Input.GetAxis("Vertical") * thrust * Time.deltaTime;
        horizontalThrust = (drone.transform.forward * pitch + drone.transform.right * roll) * drone.drag * Time.deltaTime;
        horizontalThrust.y = 0;
    }

    private void FixedUpdate()
    {
        // roll/pitch/yaw
        drone.transform.localRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward) 
            * Quaternion.AngleAxis(pitch, Vector3.right);

        //move up/down/left/right/forward/back
        drone.velocity += verticalThrust + horizontalThrust;

        //cancel / equal - gravity 0 angle relative to world
        drone.velocity += drone.transform.up * -Physics.gravity.y * Time.deltaTime;
        drone.velocity += -Physics.gravity *(1 - Vector3.Dot(drone.transform.up, Vector3.up)) * Time.deltaTime;
    }
}

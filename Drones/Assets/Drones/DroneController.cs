using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DroneController : MonoBehaviour //Flight Controller
{
    Rigidbody drone;
    DroneInput input;
    Animator animator;

    [SerializeField] float maxMoveSpeed = 70f;
    [SerializeField] float maxThrottleSpeed = 50f;
    /* [SerializeField] float timeReachMaxSpeed = 0f;
     [SerializeField] float timeReachZeroSpeed = 0f;
     [SerializeField] float timeReachMaxThrottle = 0f;*/
    [SerializeField] float maxYawSpeed = 360f;
    [SerializeField] float maxTiltSpeed = 20f;
    [SerializeField] [Range(10, 60f)] float maxRollDeg = 28f;
    [SerializeField] [Range(10, 60f)] float maxPitchDeg = 28f;
    [SerializeField] [Range(10, 60f)] float maxTiltDeg = 28f;
    [SerializeField] bool counterGravity = true;
    [SerializeField] bool autoStabalizeOrientation = true;

    float roll;
    float pitch;
    float yaw;
    Vector3 changeInVelocity;


    Vector3 thrust => drone.mass * changeInVelocity;

    #region Experimenting
    /*
    //calculate required thrust to rotate drone upright
    float tiltAcceleration = 1;
    float upsideDownAngleAccel = 2;//if drone upside down or beyong
    */

    public bool IsUpsideDown() => Vector3.Dot(transform.up, Vector3.up) < 0f;
    public float Orientation() => Vector3.Dot(transform.up, Vector3.up);
    private void OnMouseOver()
    {
        Debug.Log(Orientation().ToString());
    }
    public float TiltRate => 0f;//if is upsidedown, increase tilt acceleration so drone rotates faster.

    #endregion



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
        Vector3 moveInput = input.Drone.Move.ReadValue<Vector2>();
        float rotateInput = input.Drone.Rotate.ReadValue<float>();
        float throttleInput = input.Drone.Throttle.ReadValue<float>();

        yaw += rotateInput * maxYawSpeed * Time.deltaTime;
        roll = moveInput.x * maxRollDeg;
        pitch = moveInput.y * maxPitchDeg;

        changeInVelocity = (drone.transform.right * moveInput.x + transform.forward * moveInput.y) * maxMoveSpeed;
        changeInVelocity.y = 0;
        changeInVelocity += throttleInput  * drone.transform.up * maxThrottleSpeed;

        // cancel gravity
        if (counterGravity && drone.useGravity)
        {
            changeInVelocity += -Physics.gravity;
        }
    }


    private void FixedUpdate()
    {
        drone.angularVelocity *= 0f;
        // roll/pitch/yaw
        Quaternion targetRotation = Quaternion.AngleAxis(yaw, Vector3.up)
            * Quaternion.AngleAxis(roll, -Vector3.forward)
            * Quaternion.AngleAxis(pitch, Vector3.right);
        drone.transform.localRotation = Quaternion.Slerp(drone.transform.localRotation, targetRotation, maxTiltSpeed * Time.deltaTime);

        //move up/down/left/right/forward/back
        drone.velocity += changeInVelocity * Time.deltaTime;
    }

    private void LateUpdate()
    {
        
        //float propellerSpeed = Mathf.Clamp(Vector3.(changeInVelocity.normalized, Vector3.one), 0f, 10f);
        float propellerSpeed = Mathf.Clamp(changeInVelocity.sqrMagnitude*Time.deltaTime, -10f, 10f);
        animator.SetFloat("PropellerSpeed", propellerSpeed);
    }
}

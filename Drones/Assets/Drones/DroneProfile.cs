using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Drone", fileName = "Drone")]
public class DroneProfile : ScriptableObject
{
    public float maxMoveSpeed = 70f;
    [Range(0f, 2f)] public float timeReachMaxMoveSpeed;
    public float maxThrottleSpeed = 50f;
    [Range(0f, 2f)] public float timeReachMaxThrottleSpeed;
    public float maxYawSpeed = 360f;
    [Range(0f, 2f)] public float timeReachMaxYawSpeed;
    public float maxTilt = 28f;
    [Range(0f, 2f)] public float timeReachMaxTilt;
}

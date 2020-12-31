using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using System;

public class DroneUI : MonoBehaviour
{
    [SerializeField] Transform droneUIPanel;
    [SerializeField] Transform uiJoystickDroneYawThrottle;
    [SerializeField] Transform uiJoysticDroneMovement;
    public struct userAttr {};
    public struct appAttr {};

    public void Awake()
    {
        ConfigManager.FetchCompleted += AssignRemoteValues;
        ConfigManager.FetchConfigs<userAttr, appAttr>(new userAttr(), new appAttr());
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= AssignRemoteValues;
    }

    public void AssignRemoteValues(ConfigResponse res)
    {
        if (res.status == ConfigRequestStatus.Success)
        {
            var speed = ConfigManager.appConfig.GetFloat("speed");
            var isTrue = ConfigManager.appConfig.GetFloat("isTrue");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCameraController : MonoBehaviour
{
    Camera cam;
    Transform target;
    [SerializeField] Vector3 offsetPos = new Vector3(0, 2.5f, -8f);
    [SerializeField] Vector3 offsetTilt = new Vector3(0, 0, 0);
    [SerializeField] [Range(0f, 1f)] float moveXSpeedSnap = 1;
    [SerializeField] [Range(0f, 1f)] float moveYSpeedSnap = 1;
    [SerializeField] [Range(0f, 1f)] float moveZSpeedSnap = 1;
    [SerializeField] float turnSpeedSnap = 1;
    [SerializeField] float tiltSpeedSnap = 0;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        target = this.transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = target.TransformPoint(offsetPos);
        targetPos.y = target.transform.position.y +offsetPos.y;

        cam.transform.position = targetPos;

        var rotY = target.rotation.eulerAngles.y;
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(0, rotY, 0), turnSpeedSnap * Time.deltaTime);


        //cam.transform.rotation = Quaternion.Euler(new Vector3(0, target.rotation.eulerAngles.y, 0));
    }
}

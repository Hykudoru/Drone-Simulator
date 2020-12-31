using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCameraController : MonoBehaviour
{
    Camera cam;
    Transform target;
    [SerializeField] Vector3 camOffsetPos = new Vector3(0, 2.5f, -8f);
    [SerializeField] [Range(0f, 1f)] float camFollowSpeedSnap = .8f;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        target = this.transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.LookAt(target.TransformPoint(Vector3.forward)+Vector3.up*camOffsetPos.y);

        Vector3 targetPos = target.TransformPoint(camOffsetPos);
        targetPos.y = target.transform.position.y + camOffsetPos.y;

        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPos, camFollowSpeedSnap *.3f);
        /*
        var rotY = target.rotation.eulerAngles.y;
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(0, rotY, 0), turnSpeedSnap * Time.deltaTime);
        */
    }
}

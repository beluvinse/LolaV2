using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraPos;
    public Vector3 minPos, maxPos;
    Vector3 moveInput;

    public Transform target;

    private void FixedUpdate()
    {
        //transform.position = new Vector3(target.position.x, 22f, target.position.z -12f);
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minPos.x, maxPos.x), 22f, Mathf.Clamp(target.position.z -12f, minPos.z, maxPos.z));
    }


}

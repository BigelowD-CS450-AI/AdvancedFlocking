using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public Vector3 offset = new Vector3(0.0f, 10.0f, 0.0f);
    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.transform.position + offset;
        //transform.rotation = followTarget.transform.rotation;
    }
}

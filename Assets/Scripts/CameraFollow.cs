using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public float CamX;
    public float CamY;
    public float CamZ;

    void Update()
    {
        // Define a target position above and behind the target transform
        //  Vector3 targetPosition = target.TransformPoint(new Vector3(CamX,CamY,CamZ));
        Vector3 offset = new Vector3(CamX, CamY, CamZ);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+ offset, ref velocity, smoothTime);
    }
}

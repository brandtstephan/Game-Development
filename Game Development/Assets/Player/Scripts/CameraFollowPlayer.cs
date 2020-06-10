using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.005f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 toPos = player.position + offset;
        // transform.position = Vector3.SmoothDamp(transform.position, toPos, ref velocity, smoothTime);
        // transform.position = toPos;
        // Vector3 toVec = toPos - transform.position;
        transform.position = Vector3.Lerp(transform.position, toPos, smoothTime);
   
    }
}

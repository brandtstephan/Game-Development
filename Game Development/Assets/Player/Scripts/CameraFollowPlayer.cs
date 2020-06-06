using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.005f;
    public Vector3 offset;
    private Vector3 defaultDistance;
    public Vector3 velocity = Vector3.one;

    private void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 toPos = player.position + (player.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, smoothTime);
        transform.position = curPos + offset;
    }
}

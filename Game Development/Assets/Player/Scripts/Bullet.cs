using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;

    private float timeToLive = 3f;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeToLive);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.GetComponent<GameObject>();
        if(null != collidedObject && collidedObject.layer != LayerMask.GetMask("Player"))
        {
            Destroy(gameObject);
        }
        
    }

}

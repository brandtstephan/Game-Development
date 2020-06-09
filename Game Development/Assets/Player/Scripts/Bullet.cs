using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed;
    public Rigidbody2D rb;

    [HideInInspector]public float timeToLive;
    [HideInInspector]public float bulletDamage;
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, timeToLive);
    }
    public void setBulletDamage(int damage)
    {
        bulletDamage = damage; 
    }

    public void setTimeToLive(float time)
    {
        timeToLive = time;
    }

    public void setBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            StateController enemyController;
            collision.TryGetComponent<StateController>(out enemyController);

            if (enemyController?.enemyStats != null)
            {
                enemyController.TakeDamage((int)bulletDamage);
            }
        }

        if (null != collidedObject && collidedObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
        
    }

}

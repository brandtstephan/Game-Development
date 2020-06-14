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
    public Animator animator;

    [HideInInspector]public float timeToLive;
    [HideInInspector]public float bulletDamage;
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        RotateBulletProperly();
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

            if (enemyController?.enemyManager?.enemyStats != null)
            {
                enemyController.enemyManager.TakeDamage((int)bulletDamage);
            }
        }

        if (null != collidedObject && collidedObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("blastExplode");
    }

    private void RotateBulletProperly()
    {
        float angle = Vector2.Angle(Vector2.right, rb.velocity);
        if (rb.velocity.y < 0)
        {
            angle *= -1;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

}

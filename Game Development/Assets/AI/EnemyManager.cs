using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public DefaultEnemyStats stats;
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.rotation.y > 80)
        {
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0.0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            collision.collider.GetComponent<KnockBack>().knockbackCount = collision.collider.GetComponent<KnockBack>().knockbackLenght;
            collision.collider.GetComponent<PlayerManager>().TakeDamage((int)stats.enemyDamage);

            if(collision.collider.transform.position.x < transform.position.x)
            {
                collision.collider.GetComponent<KnockBack>().knockbackDir = true;
            }
            else
            {
                collision.collider.GetComponent<KnockBack>().knockbackDir = false;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public DefaultEnemyStats enemyStats;
    public KnockBack enemyKnockback;
    public Rigidbody2D enemyRigidBody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            collision.collider.GetComponent<KnockBack>().knockbackCount = collision.collider.GetComponent<KnockBack>().knockbackLenght;
            collision.collider.GetComponent<PlayerManager>().TakeDamage((int)enemyStats.enemyDamage);

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

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        enemyStats.isFacingRight = !enemyStats.isFacingRight;
        // Multiply the player's x local scale by -1.
        transform.Rotate(0f, 180f, 0f);
    }
    public enum AttackType
    {
        Ranged,
        Melee,
        MagicRanged,
        MagicMelee
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            if ((enemyStats.enemyHealth - damage) < 0)
            {
                enemyStats.enemyHealth = 0;
                Destroy(gameObject);
            }
            else
            {
                enemyStats.enemyHealth -= damage;
            }

        }
        enemyKnockback.ApplyKnockBack(ref enemyRigidBody);
    }
}

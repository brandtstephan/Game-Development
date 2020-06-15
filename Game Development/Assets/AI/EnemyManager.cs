using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public DefaultEnemyStats enemyStats;
    public KnockBack enemyKnockback;
    public Rigidbody2D enemyRigidBody;  
    public Animator animator;
    public bool isFacingRight;
    private float health;
    private void Start()
    {
        health = enemyStats.enemyMaximumHealth;
    }
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
        isFacingRight = !isFacingRight;
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
            if ((health - damage) < 0)
            {
                health = 0;
                SetDeathAnimation();
                return;
            }
            else
            {
                health -= damage;
            }

        }
        enemyKnockback.ApplyKnockBack(ref enemyRigidBody);
    }

    public void DoAttack()
    {
            switch (enemyStats.attackType)
            {
                case AttackType.Melee:
                    MeleeAttack();
                    break;
                case AttackType.Ranged:
                    RangedAttack();
                    break;
                case AttackType.MagicMelee:
                    MagicMeleeAttack();
                    break;
                case AttackType.MagicRanged:
                    MagicRangedAttack();
                    break;
                default:
                    break;

            }
    }
    private void MeleeAttack()
    {
        Debug.Log("MELEE");
    }
    private void RangedAttack()
    {

    }
    private void MagicRangedAttack()
    {

    }
    private void MagicMeleeAttack()
    {

    }

    private void SetDeathAnimation()
    {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        enemyRigidBody.velocity = Vector2.zero;
        enemyRigidBody.isKinematic = true;
        GetComponent<StateController>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{

    public PlayerManager playerManager;
    private float nextAttackTime = 0f;
    private void Update()
    {
        DoAttack();   
    }
    public void DoAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (null != playerManager && playerManager.weapon != null)
            {
                switch (playerManager.stats.primaryAttackType)
                {
                    case PlayerManager.AttackType.Melee:
                        MeleeAttack();
                        break;
                    case PlayerManager.AttackType.Ranged:
                        RangedAttack();
                        break;
                    case PlayerManager.AttackType.MagicMelee:
                        MagicMeleeAttack();
                        break;
                    case PlayerManager.AttackType.MagicRanged:
                        MagicRangedAttack();
                        break;
                    default:
                        break;

                }

            }
            
        }
    }

    private void MeleeAttack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerManager.animator.SetTrigger("Attack");
            ResetAttackTimer();
        }
    }
    private void RangedAttack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerManager.animator.SetTrigger("MagicAttack");
            ResetAttackTimer();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {       
            
        }
    }
    private void MagicRangedAttack()
    {

    }
    private void MagicMeleeAttack()
    {

    }

    private void ResetAttackTimer()
    {
        nextAttackTime = Time.time + (1f / playerManager.stats.attackRate);
    }
}

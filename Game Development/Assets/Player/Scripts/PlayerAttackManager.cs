using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{

    public PlayerManager playerManager;
    private bool isAttacking = false; 
    private void Update()
    {
        DoAttack();
       
    }
    public void DoAttack()
    {
        if (null != playerManager && playerManager.weapon != null)
        {
                switch (playerManager.stats.primaryAttackType)
                {
                    case StateController.AttackType.Melee:
                        MeleeAttack();
                        break;
                    case StateController.AttackType.Ranged:
                        RangedAttack();
                        break;
                    case StateController.AttackType.MagicMelee:
                        MagicMeleeAttack();
                        break;
                    case StateController.AttackType.MagicRanged:
                        MagicRangedAttack();
                        break;
                    default:
                        //Invoke("ResetAttack", 3f);
                        break;

                }
            
        }
    }

    private void MeleeAttack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isAttacking)
        {
            playerManager.animator.SetTrigger("Attack");
            isAttacking = true;
        }
    }
    private void RangedAttack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isAttacking)
        {
            playerManager.weapon.Shoot();
            //isAttacking = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && !isAttacking)
        {       
            
            //isAttacking = true;
        }
    }
    private void MagicRangedAttack()
    {

    }
    private void MagicMeleeAttack()
    {

    }

    public void ResetAttack()
    {
        isAttacking = false;
    }
}

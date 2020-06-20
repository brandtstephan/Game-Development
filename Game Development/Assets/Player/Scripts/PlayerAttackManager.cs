﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    private float nextAttackTime = 0f;
    private void Update()
    {
        PlayerManager.Instance.isAttacking = false;
        DoAttack();   
    }
    public void DoAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (null != PlayerManager.Instance && PlayerManager.Instance.weapon != null)
            {  
                switch (PlayerManager.Instance.stats.primaryAttackType)
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
        else
        {
            PlayerManager.Instance.isAttacking = true;
        }
    }
    private void MeleeAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
        }
    }
    private void RangedAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PlayerManager.Instance.isAttacking = true;
            PlayerManager.Instance.animator.SetTrigger("MagicAttack");  
            ResetAttackTimer();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            PlayerManager.Instance.isAttacking = true;
            PlayerManager.Instance.animator.SetTrigger("Attack");           
            ResetAttackTimer();
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
        nextAttackTime = Time.time + (1f / PlayerManager.Instance.stats.attackRate);
    }
}

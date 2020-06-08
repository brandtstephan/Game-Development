using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{

    public Weapon weapon;
    public PlayerStats playerStats;
    private void Update()
    {
        DoAttack();
    }
    public void DoAttack()
    {
        if (null != playerStats && weapon != null)
        {
                switch (playerStats.attackType)
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
                        break;

                }
        }
    }

    private void MeleeAttack()
    {

    }
    private void RangedAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot();
        }
    }
    private void MagicRangedAttack()
    {

    }
    private void MagicMeleeAttack()
    {

    }
}

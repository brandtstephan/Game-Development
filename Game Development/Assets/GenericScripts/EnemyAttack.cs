using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Attack/BasicAttack")]
public class EnemyAttack : Attack
{
    public override void DoAttack(StateController controller = null, PlayerStats playerStats = null, DefaultEnemyStats enemyStats = null)
    {
        if (null != controller)
        {
            switch (controller.enemyManager.enemyStats.attackType)
            {
                case EnemyManager.AttackType.Melee:
                    MeleeAttack(controller);
                    break;
                case EnemyManager.AttackType.Ranged:
                    RangedAttack(controller);
                    break;
                case EnemyManager.AttackType.MagicMelee:
                    MagicMeleeAttack(controller);
                    break;
                case EnemyManager.AttackType.MagicRanged:
                    MagicRangedAttack(controller);
                    break;
                default:
                    break;

            }
        }
    }
    private void MeleeAttack(StateController controller = null)
    {
        //Debug.Log("PEWPEW");

    }
    private void RangedAttack(StateController controller = null)
    {

    }
    private void MagicRangedAttack(StateController controller = null)
    {

    }
    private void MagicMeleeAttack(StateController controller = null)
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Attack/BasicAttack")]
public class EnemyAttack : Attack
{
    public override void DoAttack(StateController controller = null)
    {
        if (null != controller)
        {
            switch (controller.enemyStats.attackType)
            {
                case StateController.AttackType.Melee:
                    MeleeAttack(controller);
                    break;
                case StateController.AttackType.Ranged:
                    RangedAttack(controller);
                    break;
                case StateController.AttackType.MagicMelee:
                    MagicMeleeAttack(controller);
                    break;
                case StateController.AttackType.MagicRanged:
                    MagicRangedAttack(controller);
                    break;
                default:
                    break;

            }
        }
    }

    private void MeleeAttack(StateController controller = null)
    {
        Debug.Log("PEWPEW");
        
    }
    private void RangedAttack(StateController controller = null)
    {

    }
    private void MagicRangedAttack(StateController controller= null)
    {

    }
    private void MagicMeleeAttack(StateController controller = null)
    {

    }
}

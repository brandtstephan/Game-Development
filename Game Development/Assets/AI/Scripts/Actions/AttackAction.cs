using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    private float nextAttackTime = 0f;
    public override void Act(StateController controller)
    {
        Attack(controller);      
    }

    private void Attack(StateController controller)
    {
        if (Time.time >= nextAttackTime)
        {
            controller.enemyManager.animator.SetTrigger("IsAttacking");
            nextAttackTime = Time.time + (1 / controller.enemyManager.enemyStats.attackRate);
        }     
    }

}

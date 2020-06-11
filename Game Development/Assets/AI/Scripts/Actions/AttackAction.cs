using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);      
    }

    private void Attack(StateController controller)
    {
        //Attack rate
        if (controller.CheckElapsedTime(controller.enemyManager.enemyStats.attackRate))
        {
            controller.enemyManager.enemyStats.enemyAttack.DoAttack(controller);
        }     
    }

}

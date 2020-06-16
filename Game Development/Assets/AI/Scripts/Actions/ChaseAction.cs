﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        controller.enemyManager.animator.SetTrigger("IsWalking");
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        if (controller.chaseTarget != null)
        {
            HandleDirection(controller);
        }    
        controller.transform.Translate(2 * controller.enemyManager.enemyStats.chaseSpeed * Time.deltaTime *-1 , 0, 0);
    }

    private void HandleDirection(StateController controller)
    {
        if (controller.chaseTarget.position.x > controller.transform.position.x && !controller.enemyManager.isFacingRight)
        {
            // ... flip the player.
            controller.enemyManager.Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (controller.chaseTarget.position.x < controller.transform.position.x && controller.enemyManager.isFacingRight)
        {
            // ... flip the player.
            controller.enemyManager.Flip();
        }
    }

}

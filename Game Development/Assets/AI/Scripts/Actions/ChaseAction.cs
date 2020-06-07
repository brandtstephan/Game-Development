using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        float playerDirection = (controller.chaseTarget.position - controller.transform.position).normalized.x;
        float enemyDirection = controller.transform.localScale.x;
        playerDirection /= Mathf.Abs(playerDirection);
            
        if (playerDirection != enemyDirection)
        {
            controller.Flip();

        }
        controller.transform.Translate(2 * controller.enemyStats.chaseSpeed * Time.deltaTime * enemyDirection , 0, 0);
    }

}

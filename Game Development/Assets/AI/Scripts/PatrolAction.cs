using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {

        float speed = controller.enemyStats.movSpeed;
        float direction = controller.enemyStats.enemyDirection;

        controller.transform.Translate(2 * Time.deltaTime * speed, 0 ,0);

    }
}

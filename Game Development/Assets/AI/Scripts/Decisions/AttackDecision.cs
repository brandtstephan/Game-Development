using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Attack")]
public class AttackDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return AttackIfRangeAllow(controller);
    }

    private bool AttackIfRangeAllow(StateController controller)
    {
        float dist = Vector2.Distance(controller.chaseTarget.position, controller.transform.position);

        //Check if attack range is reached 
        if (dist <= controller.enemyStats.attackDistance)
        {
            return true;
        }
        return false;
    }
}

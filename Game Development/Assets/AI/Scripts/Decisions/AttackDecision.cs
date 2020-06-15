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

        if (dist <= controller.enemyManager.enemyStats.attackDistance)
        {
            return true;
        }
        return false;
    }
}

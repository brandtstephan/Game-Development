﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckDistanceToTarget(controller);
    }

    private bool CheckDistanceToTarget(StateController controller)
    {
        if (controller?.chaseTarget?.position == null)
        {
            return false;
        }
        float distance = Vector2.Distance((Vector2)controller.chaseTarget.position, (Vector2)controller.transform.position);
        if (distance < controller.enemyManager.enemyStats.lookRadius)
        {
            return true;
        }
        return false;
    }
}

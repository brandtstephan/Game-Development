using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Jump")]
public class JumpAction : Action
{
    public override void Act(StateController controller)
    {
        Jump(controller);
    }

    private void Jump(StateController controller)
    {
            controller.enemyRigidBody.AddForce(new Vector2(0f, controller.enemyManager.enemyStats.jumpForce));
            controller.isGrounded = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Jump")]
public class JumpDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return JumpIfRaycastHitsWall(controller);

    }

    private bool JumpIfRaycastHitsWall(StateController controller)
    {
        float direction = controller.enemyManager.isFacingRight ? 1f : -1f;

        Vector2 dir = new Vector2(direction, 0.0f);

        RaycastHit2D hitWall = Physics2D.Raycast(controller.eyes.position, dir, controller.enemyManager.enemyStats.distanceJumpAction, LayerMask.GetMask("Ground"));
        RaycastHit2D hitCanJump= Physics2D.Raycast(controller.wallChecker.position, dir, controller.enemyManager.enemyStats.distanceJumpAction * 1.5f, LayerMask.GetMask("Ground"));

        if (hitWall.collider != null && controller.isGrounded && hitCanJump.collider == null)
        {
            return true;
        }

        return false;
    }
}

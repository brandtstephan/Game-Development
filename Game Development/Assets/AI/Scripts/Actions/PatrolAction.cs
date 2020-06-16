using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        controller.enemyManager.animator.SetTrigger("IsWalking");
        Patrol(controller);
        
        if (CheckSurrounding(controller))
        {
            controller.enemyManager.Flip();
        }
    }

    private void Patrol(StateController controller)
    {
        float speed = controller.enemyManager.enemyStats.movSpeed;
        float direction = controller.transform.localScale.x;

        controller.transform.Translate(2 * Time.deltaTime * speed * -1, 0 ,0);
    }

    private bool CheckSurrounding(StateController controller)
    {
        float direction = controller.enemyManager.isFacingRight ? 1f : -1f;

        Vector2 dir = new Vector2(direction, 0.0f);

        RaycastHit2D hitWall = Physics2D.Raycast(controller.eyes.position, dir, controller.enemyManager.enemyStats.distanceJumpAction, LayerMask.GetMask("Ground"));
        RaycastHit2D hitCanJump = Physics2D.Raycast(controller.wallChecker.position, dir, controller.enemyManager.enemyStats.distanceJumpAction * 1.5f, LayerMask.GetMask("Ground"));

        if (hitWall.collider != null && controller.isGrounded && hitCanJump.collider != null)
        {
            return true;
        }
        return false;
    }

}

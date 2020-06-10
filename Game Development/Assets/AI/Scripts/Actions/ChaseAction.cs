using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    private bool m_FacingRight = false;
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        float playerDirection = (controller.chaseTarget.position - controller.transform.position).normalized.x;
        float enemyDirection = 0;
        playerDirection /= Mathf.Abs(playerDirection);

        if (controller.chaseTarget.position.x < controller.transform.position.x)
        {
            Debug.Log(enemyDirection);
            //controller.transform.localScale = new Vector2(-1,controller.transform.localScale.y);
            enemyDirection = -1;

        }
        else
        {
            //controller.transform.localScale = new Vector2(1, controller.transform.localScale.y);
            enemyDirection = 1;
        }
        controller.transform.Translate(2 * controller.enemyStats.chaseSpeed * Time.deltaTime * enemyDirection , 0, 0);
    }

    private void HandleDirection(StateController controller)
    {
        if (controller.chaseTarget.position.x > controller.transform.position.x && m_FacingRight && !m_FacingRight)
        {
            // ... flip the player.
            Flip(controller.transform);
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (controller.chaseTarget.position.x < controller.transform.position.x && m_FacingRight)
        {
            // ... flip the player.
            Flip(controller.transform);
        }
    }

    private void Flip(Transform enemyTransform)
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        // Multiply the player's x local scale by -1.
        enemyTransform.Rotate(0f, 180f, 0f);
    }

}

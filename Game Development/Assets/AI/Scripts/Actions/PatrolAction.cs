using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
        
        if (controller.CheckElapsedTimeToFlip())
        {
            controller.Flip();
        }
    }

    private void Patrol(StateController controller)
    {
        float speed = controller.enemyStats.movSpeed;
        float direction = controller.transform.localScale.x;

        controller.transform.Translate(2 * Time.deltaTime * speed * direction*-1, 0 ,0);
    }

}

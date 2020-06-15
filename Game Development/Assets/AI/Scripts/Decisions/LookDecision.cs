using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return LookIfTargetVisible(controller);
        
    }

    private bool LookIfTargetVisible(StateController controller)
    {

        List<Collider2D> listOfColliders = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Player"));

        if (Physics2D.OverlapCircle(controller.eyes.position, controller.enemyManager.enemyStats.lookRadius, filter, listOfColliders) > 0)
        {
            controller.chaseTarget = listOfColliders.ElementAt(0).transform;
            return true;
        }  
        return false;
    }

}

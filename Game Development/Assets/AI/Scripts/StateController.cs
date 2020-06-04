using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;
using Vector2 = UnityEngine.Vector2;

public class StateController : MonoBehaviour
{
    public DefaultEnemyStats enemyStats;
    public State currentState;
    private bool aiActive;
    public Color sceneGizmoColor = Color.red;
    public Transform eyes;

    void Update()
    {
        if (!aiActive)
        {
            return;
        }
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = sceneGizmoColor;
            Ray ray = new Ray(eyes.position,transform.right);
            Gizmos.DrawRay(ray);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class StateController : MonoBehaviour
{
    public DefaultEnemyStats enemyStats;
    public State currentState;
    private bool aiActive;
    public Color sceneGizmoColor = Color.red;
    public Transform eyes;
    private float startTime;
    public Rigidbody2D enemyRigidBody;
    public State remainState;

    [HideInInspector] public Transform chaseTarget;

    private void Start()
    {
        startTime = setStartTime();
        aiActive = true;
    }
    void Update()
    {
        if (!aiActive)
        {
            return;
        }
        if (CheckElapsedTime(enemyStats.enemyWaitTime))
        {

            Flip();
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

    private bool CheckElapsedTime(float maxTime)
    {
        if ((Time.time - startTime) >= maxTime)
        {

            startTime = setStartTime();
            return true;
        }
        return false;
    }
    private float setStartTime()
    {
        return Time.time;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        
        // Multiply the player's x local scale by -1.
        transform.Rotate(0f, 180f, 0f);
        enemyStats.enemyDirection *= -1;
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}

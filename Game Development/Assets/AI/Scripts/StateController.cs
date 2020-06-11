using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class StateController : MonoBehaviour
{
    public EnemyManager enemyManager;
    public State currentState;
    private bool aiActive;
    public Color sceneGizmoColor = Color.red;
    public Transform eyes;
    private float startTime;
    public Rigidbody2D enemyRigidBody;
    public State remainState;

    [HideInInspector] public Transform chaseTarget;

    private void Awake()
    {
        enemyManager.enemyStats.enemyHealth = enemyManager.enemyStats.enemyMaximumHealth;
    }
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

        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = sceneGizmoColor;
            Ray ray = new Ray(eyes.position,transform.right);
            //Gizmos.DrawRay(ray);
            Gizmos.DrawWireSphere(eyes.position, enemyManager.enemyStats.lookRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(eyes.position, enemyManager.enemyStats.attackDistance);
        }
    }

    public bool CheckElapsedTimeToFlip()
    {
        if ((Time.time - startTime) >= enemyManager.enemyStats.enemyWaitTime)
        {
            startTime = setStartTime();
            return true;
        }
        return false;
    }

    public bool CheckElapsedTime(float time)
    {
        if ((Time.time - startTime) >= time)
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

    

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}

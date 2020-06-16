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
    public bool isGrounded = true;
    public Transform wallChecker;

    [HideInInspector] public Transform chaseTarget;
    private void Start()
    {
        startTime = setStartTime();
        aiActive = true;
        chaseTarget = null;
    }
    void Update()
    {
        if (!aiActive)
        {
            return;
        }

        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {

        List<Collider2D> listOfColliders = new List<Collider2D>();
        ContactFilter2D groundLayer = new ContactFilter2D();
        groundLayer.SetLayerMask(LayerMask.GetMask("Ground"));

        if (Physics2D.OverlapCollider(GetComponent<Collider2D>(), groundLayer, listOfColliders) > 0)
        {
            isGrounded = true;
        }
    }

    void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            //Gizmos.color = sceneGizmoColor;
            
            float direction = enemyManager.isFacingRight ? 1f : -1f;

            Vector2 dir = new Vector2(direction * enemyManager.enemyStats.distanceJumpAction, 0.0f);
            Vector2 dir2 = new Vector2(direction * enemyManager.enemyStats.distanceJumpAction * 1.5f, 0.0f);
            //Gizmos.DrawRay(ray);
            //Gizmos.DrawWireSphere(eyes.position, enemyManager.enemyStats.lookRadius);
            //Gizmos.color = Color.green;
            //Gizmos.DrawWireSphere(eyes.position, enemyManager.enemyStats.attackDistance);
            Debug.DrawRay(eyes.position, dir);
            Debug.DrawRay(wallChecker.position, dir2, Color.red);
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

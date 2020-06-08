using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;

    private float horizontalMovement = 0f;
    public float runSpeed = 40f;
    private bool jump = false;
    private bool isTouchingGround = true;

    public Animator animator;

    private Vector3 lastAcceleration;
    private Vector3 lastVelocity;
    private Vector3 lastPosition;

    public BoxCollider2D groundCollider;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        if(Input.GetButtonUp("Jump")){
            animator.SetBool("JumpStart", false);
        }
        DisplayJumpingAnimation();
        DisplayCorrectLandingAnimation();
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime ,false,jump);
        jump = false;
    }

    private void DisplayJumpingAnimation()
    {
        Vector3 position = transform.position;
        Vector3 velocity = (position - lastPosition) / Time.deltaTime;
        Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;

        Debug.Log(isTouchingGround);
        if (velocity.y < 0 && !isTouchingGround)
        {
            // Decelerating
            Debug.Log("GotTriggered");
            animator.SetTrigger("JumpFall");
        }
        
        lastAcceleration = acceleration;
        lastVelocity = velocity;
        lastPosition = position;
    }

    private void DisplayCorrectLandingAnimation()
    {
        List<Collider2D> listOfColliders = new List<Collider2D>();
        ContactFilter2D groundLayer = new ContactFilter2D();
        groundLayer.SetLayerMask(LayerMask.GetMask("Ground"));

        if (Physics2D.OverlapCollider(groundCollider, groundLayer, listOfColliders) > 0 )
        {
            isTouchingGround = true;
        }
        else
        {
            isTouchingGround = false;
        }
    }
}

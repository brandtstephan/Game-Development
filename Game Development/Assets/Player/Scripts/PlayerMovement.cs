using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;

    private float horizontalMovement = 0f;
    private bool jump = false;

    public Animator animator;

    public BoxCollider2D groundCollider;
    public bool canMove = true;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if(horizontalMovement == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime * controller.playerManager.stats.playerRunSpeed, jump);
        jump = false;
    }
    public void MoveCharacter()
    {
        canMove = !canMove;
    }
}

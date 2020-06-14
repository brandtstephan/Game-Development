﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMovement = 0f;
    private bool jump = false;

    public Animator animator;

    public BoxCollider2D groundCollider;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

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

        controller.Move(horizontalMovement * Time.fixedDeltaTime * controller.playerManager.stats.playerRunSpeed, jump);
        jump = false;

    }
}

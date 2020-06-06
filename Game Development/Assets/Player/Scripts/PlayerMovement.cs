﻿using System;
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

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime ,false,jump);
        jump = false;
    }
}
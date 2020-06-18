using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class CharacterController2D : MonoBehaviour
{	
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	public Collider2D ceilingCollider;											// A collider that will be disabled when crouching
	public BoxCollider2D groundCollider;

	private bool isGrounded;													// Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;                                           // For determining which way the player is currently facing.

	public Animator animator;
	public KnockBack knockbackManager;

	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping = false;
	private bool jump = false;

	public float rollCooldown;
	private float nextRoll = 0f;

	private float horizontalMovement = 0f;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		horizontalMovement = Input.GetAxisRaw("Horizontal");

		if (isGrounded)
		{
			animator.SetBool("isJumping", false);
		}
		else
		{
			animator.SetBool("isJumping", true);
		}

		if (horizontalMovement == 0)
		{
			animator.SetBool("isRunning", false);
		}
		else
		{
			animator.SetBool("isRunning", true);
		}

	}
	private void FixedUpdate()
	{
	
		isGrounded = false;

		List<Collider2D> listOfColliders = new List<Collider2D>();
		ContactFilter2D groundLayer = new ContactFilter2D();
		groundLayer.SetLayerMask(LayerMask.GetMask("Ground"));

		if(Physics2D.OverlapCollider(groundCollider, groundLayer, listOfColliders) > 0)
		{
			isGrounded = true;	
		}

		if (Input.GetButton("Jump"))
		{
			jump = true;
		}
		Debug.Log(Time.time >= nextRoll);
		if (Time.time >= nextRoll)
		{
			if (Input.GetKey(KeyCode.LeftShift) && !jump)
			{
				RollDodge();
				nextRoll = Time.time + (1 / rollCooldown);
			}	
		}
		Move(horizontalMovement, jump);
		jump = false;
	}

    public void Move(float move, bool jump)
	{
		if (isGrounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * PlayerManager.Instance.stats.playerRunSpeed, m_Rigidbody2D.velocity.y);

			if (knockbackManager.knockbackCount <= 0)
			{
				m_Rigidbody2D.velocity = targetVelocity;
			}
			else
			{
				knockbackManager.ApplyKnockBack(ref m_Rigidbody2D);
			}
			
			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}

		if (isGrounded && jump)
		{
			animator.SetTrigger("JumpStart");
			PlayerManager.Instance.CreateDust();
			isGrounded = false;
			isJumping = true;
			jumpTimeCounter = jumpTime;
			m_Rigidbody2D.velocity = new Vector2(move * (PlayerManager.Instance.stats.playerRunSpeed/1.5f), PlayerManager.Instance.stats.playerJumpForce);
		}
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
				m_Rigidbody2D.velocity = new Vector2(move * (PlayerManager.Instance.stats.playerRunSpeed / 1.5f), PlayerManager.Instance.stats.playerJumpForce);
				jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
				isJumping = false;
            }
			
		}

        if (Input.GetKeyUp(KeyCode.Space))
        {
			isJumping = false;
        }
	   

	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f,180f,0f);
	}

    private void OnDrawGizmos()
    {
		/*Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(m_GroundCheck.position, k_GroundedRadius);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(m_CeilingCheck.position, k_CeilingRadius);
		*/
	}

	public void RollDodge()
    {
        if (!isGrounded)
        {
			return;
        }
		animator.SetTrigger("IsRolling");
		PlayerManager.Instance.CreateDust();
		ceilingCollider.enabled = false;
        PlayerManager.Instance.stats.playerRunSpeed = PlayerManager.Instance.stats.rollingSpeedMultiplier;
	}

	public void EnableCeilingCollider()
    {
        if (!ceilingCollider.enabled)
        {
			ceilingCollider.enabled = true;
        }
		PlayerManager.Instance.stats.playerRunSpeed = PlayerManager.Instance.stats.playerInitialSpeed;

	}
}

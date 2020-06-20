using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{	
	//Collider Values				
	public Collider2D ceilingCollider;											
	public BoxCollider2D groundCollider;												

	private bool isGrounded;

	//Knockback
	public KnockBack knockbackManager;

	//Jumping Values
	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping = false;
	private bool jump = false;
	private Vector3 currentVelocity = Vector3.zero;
	public float smoothAirControll = 0.5f;

	//Roll Values
	public float rollCooldown;
	private float nextRoll = 0f;

	//Running Values
	private bool isFacingRight = true;  
	private float horizontalMovement = 0f;

	private void Update()
	{
        if (PlayerManager.Instance.isAttacking)
        {
			horizontalMovement = 0f;
        }
        else
        {
			horizontalMovement = Input.GetAxisRaw("Horizontal");

			if (Input.GetButton("Jump"))
			{
				jump = true;
			}
		}
			
		ManageAnimations();
	}
	private void FixedUpdate()
	{
		isGrounded = false;

		List<Collider2D> listOfColliders = new List<Collider2D>();
		ContactFilter2D groundLayer = new ContactFilter2D();
		groundLayer.SetLayerMask(LayerMask.GetMask("Ground"));

		isGrounded = (Physics2D.OverlapCollider(groundCollider, groundLayer, listOfColliders) > 0);	

        Move();
        Jump(jump);
        FlipDirection();
        RollDodge();

        jump = false;
	}

    private void Move()
	{
		if (isGrounded)
		{
			Vector3 targetVelocity = new Vector2(horizontalMovement * PlayerManager.Instance.stats.playerRunSpeed, PlayerManager.Instance.playerRigidBody.velocity.y);
			
			if (knockbackManager.knockbackCount <= 0)
			{
				PlayerManager.Instance.playerRigidBody.velocity = targetVelocity;
			}
			else
			{
				knockbackManager.ApplyKnockBack(ref PlayerManager.Instance.playerRigidBody);
			}
        }
        else
        {
			Vector3 targetVelocity = new Vector2(horizontalMovement * (PlayerManager.Instance.stats.playerRunSpeed/2f), PlayerManager.Instance.playerRigidBody.velocity.y);
			PlayerManager.Instance.playerRigidBody.velocity = Vector3.SmoothDamp(PlayerManager.Instance.playerRigidBody.velocity, targetVelocity, ref currentVelocity, smoothAirControll);
		}
	}

	private void Jump(bool jump)
    {
		if (isGrounded && jump)
		{
			PlayerManager.Instance.animator.SetTrigger("JumpStart");
			PlayerManager.Instance.CreateDust();
			isGrounded = false;
			isJumping = true;
			jumpTimeCounter = jumpTime;

			PlayerManager.Instance.playerRigidBody.velocity = new Vector2(horizontalMovement * (PlayerManager.Instance.stats.playerRunSpeed / 1.5f), PlayerManager.Instance.stats.playerJumpForce);

		}
		if (Input.GetKey(KeyCode.Space) && isJumping)
		{
			if (jumpTimeCounter > 0)
			{
				PlayerManager.Instance.playerRigidBody.velocity = new Vector2(horizontalMovement * (PlayerManager.Instance.stats.playerRunSpeed / 1.5f), PlayerManager.Instance.stats.playerJumpForce);
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

	private void FlipDirection()
    {
		if (horizontalMovement > 0 && !isFacingRight)
		{
			Flip();
		}
		else if (horizontalMovement < 0 && isFacingRight)
		{
			Flip();
		}
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		transform.Rotate(0f,180f,0f);
	}

	private void RollDodge()
    {

		if (Time.time >= nextRoll)
		{
			if (Input.GetKey(KeyCode.LeftShift) && !jump)
			{

				if (!isGrounded)
				{
					return;
				}
				PlayerManager.Instance.animator.SetTrigger("IsRolling");
				PlayerManager.Instance.CreateDust();
				ceilingCollider.enabled = false;
				PlayerManager.Instance.stats.playerRunSpeed = PlayerManager.Instance.stats.rollingSpeedMultiplier;

				nextRoll = Time.time + (1 / rollCooldown);
			}
		}
		
	}

	public void EnableCeilingCollider()
    {
        if (!ceilingCollider.enabled)
        {
			ceilingCollider.enabled = true;
        }
		PlayerManager.Instance.stats.playerRunSpeed = PlayerManager.Instance.stats.playerInitialSpeed;

	}

	private void ManageAnimations()
    {
		if (isGrounded)
		{
			PlayerManager.Instance.animator.SetBool("isJumping", false);
		}
		else
		{
			PlayerManager.Instance.animator.SetBool("isJumping", true);
		}

		if (horizontalMovement == 0)
		{
			PlayerManager.Instance.animator.SetBool("isRunning", false);
		}
		else
		{
			PlayerManager.Instance.animator.SetBool("isRunning", true);
		}
	}
}

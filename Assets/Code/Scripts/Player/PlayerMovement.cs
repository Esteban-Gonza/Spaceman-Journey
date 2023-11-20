using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 16f;
    private float horizontalMovement;
    private bool isFacingRight = true;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckRadious = 0.2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("Jump Buffering")]
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [Header("References")]
    private Rigidbody2D playerRigid;
    private Animator playerAnim;
    private PlayerController playerController;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            Jump();

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W) && playerRigid.velocity.y > 0f)
        {
            ReleaseJump();

            coyoteTimeCounter = 0f;
        }
            
        Flip();

        playerAnim.SetFloat("HorizontalMovement", horizontalMovement);
        playerAnim.SetBool("IsGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
        if(playerController.canMove)
            playerRigid.velocity = new Vector2(horizontalMovement * speed, playerRigid.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, groundLayer);
    }

    private void Jump()
    {
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpForce);
    }

    private void ReleaseJump()
    {
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, playerRigid.velocity.y * 0.5f);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
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

    [Header("References")]
    private Rigidbody2D playerRigid;
    private Animator playerAnim;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) && IsGrounded())
            Jump();

        if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W) && playerRigid.velocity.y > 0f)
            ReleaseJump();

        Flip();

        playerAnim.SetFloat("HorizontalMovement", horizontalMovement);
        playerAnim.SetBool("IsGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
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
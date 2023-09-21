using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    private Rigidbody2D rb;
    private Transform groundCheck;
    private bool isGrounded;

    private float originalMoveSpeed;
    private float speedBoostEndTime;

    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        originalMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        if (Time.time >= speedBoostEndTime)
        {
            moveSpeed = originalMoveSpeed;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (isGrounded)
        {
            rb.velocity = movement;
        }
        else
        {
            // Check if there's an obstacle in the player's path.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude * Time.deltaTime, groundLayer);

            // If there's an obstacle, adjust the player's position.
            if (hit.collider != null)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y); // Stop horizontal movement
                transform.position = new Vector2(hit.point.x, transform.position.y);
            }
            else
            {
                rb.velocity = movement;
            }
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Apply fall multiplier when falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void ApplySpeedBoost(float amount, float boostDuration)
    {
        moveSpeed += amount;
        speedBoostEndTime = Time.time + boostDuration;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

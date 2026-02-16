using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int health = 100; // Player health
    public float speed = 5f; // Player movement speed
    public float jumpForce = 10f; // Force applied when the player jumps
    public Transform groundCheck; // Transform used to check if the player is grounded
    public float groundCheckRadius = 0.2f; // Radius for the ground check
    public LayerMask groundLayer; // Layer mask to identify what is considered ground
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component
    private bool isGrounded; // Flag to check if the player is on the ground
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator; // Reference to the Animator component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public int extraJumpsValue = 1;
    private int extraJumps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to the player

        extraJumps = extraJumpsValue; // Initialize extra jumps to the specified value
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Set the player's velocity based on input and speed

        if (isGrounded)
        {
            extraJumps = extraJumpsValue; // Reset extra jumps when grounded
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed and the player is grounded
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply a vertical force to make the player jump
            }
            else if(extraJumps > 0)
            {
               rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply a vertical force to make the player jump
               extraJumps--; // Decrease the number of extra jumps left
            }
        }

        setAnimation(moveInput);
    }
    private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if the player is grounded using an overlap circle
        }

        private void setAnimation(float moveInput)
        {
            if (isGrounded)
            {
                if (moveInput == 0)
                {
                    animator.Play("Player_idle"); // Play idle animation when the player is not moving
                }
                else
                {
                    animator.Play("Player_Run"); // Play running animation when the player is moving
                }    
                    }
                    else
                    {
                    if(rb.linearVelocityY > 0)
                    {
                        animator.Play("Player_Jump"); // Play jump animation when the player is moving upwards
                    }
                    else
                    {
                        animator.Play("Player_Fall"); // Play fall animation when the player is moving downwards
                    }
                    }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply a vertical force to make the player jump
            StartCoroutine(BlinkRed());

            if (health <= 0)
            {
                Die();
            }
        }
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red; // Change the sprite color to red
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        spriteRenderer.color = Color.white; // Change the sprite color back to white
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // Reload the current scene (scene index 0)
    }

}

using UnityEngine;

public class PlayerMovementWithAnimation : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float jumpForce = 5f; // Jump force
    public LayerMask groundLayer; // Layer for ground detection

    private Rigidbody rb; // Reference to Rigidbody
    private Animator animator; // Reference to Animator
    private bool isGrounded; // Tracks if the player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Ensure the Animator is attached
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimations();
    }

    private void HandleMovement()
    {
        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = new Vector3(x, 0, z).normalized;

        // Apply movement
        Vector3 newPosition = rb.position + move * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    private void HandleJump()
    {
        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        // Jump if the player presses the jump button and is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void UpdateAnimations()
    {
        // Get the player's velocity in the XZ plane (ignoring Y for jump)
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Check if the player is moving
        bool isMoving = horizontalVelocity.magnitude > 0.1f;

        // Update Animator parameters
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsGrounded", isGrounded);
    }
}


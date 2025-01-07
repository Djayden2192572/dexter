using UnityEngine;

public class AnimatedMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float jumpForce = 5f; // Jump force
    public LayerMask groundLayer; // Ground layer to detect ground

    private Rigidbody rb; // Rigidbody reference
    private Animator animator; // Animator reference
    private bool isGrounded; // Check if player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Ensure your player has an Animator
    }

    void Update()
    {
        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = new Vector3(x, 0, z).normalized;

        // Apply movement
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // Check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Update animations
        bool isMoving = move.magnitude > 0; // Check if the player is moving
        animator.SetBool("IsMoving", isMoving); // Set the "IsMoving" parameter
        animator.SetBool("IsGrounded", isGrounded); // Set the "IsGrounded" parameter
    }
}

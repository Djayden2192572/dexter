using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed
    public float jumpForce = 7f;  // Jump force
    public LayerMask groundLayer; // Layer for ground detection

    private Rigidbody rb;         // Reference to Rigidbody
    private bool isGrounded;      // Check if player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
    }

    void Update()
    {
        // Horizontal and Vertical input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Apply movement
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = newVelocity;

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("aangeroept");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Check if player is grounded using raycast
        float distanceToGround = 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround, groundLayer);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jensier : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float jumpForce; // Add a separate variable for jump force.
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the Rigidbody component is fetched.
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up * -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            print("aangeroept");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Check if the player is grounded.
    private bool IsGrounded()
    {
        // Perform a small raycast downwards to check for the ground.
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}



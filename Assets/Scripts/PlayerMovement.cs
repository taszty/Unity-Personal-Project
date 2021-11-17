using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public CharacterController controller;

    public float speed = 5f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if off ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Change velocity once player collides with ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Collect movement inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Define movement specifications
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Set velocity for use of gravity
        velocity.y += gravity * Time.deltaTime;

        // Assign the gravity movement, multiply by time.deltatime again to satisfy velocity equation
        controller.Move(velocity * Time.deltaTime);

        // Add animation transition condition
        // animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        // animator.SetFloat("Speed Horizontal", Input.GetAxis("Horizontal"));
    }
}

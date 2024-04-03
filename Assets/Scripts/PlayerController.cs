using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f; // walking speed
    public float sprintSpeed = 10f; //sprinting speed
    public float jumpForce = 10f; //jumping force
    public float gravity = -9.81f;
    public Transform groundCheck; //Object to check if grounded
    public LayerMask groundMask; // Layer mask for ground objects

    private CharacterController characterController;
    private bool isGrounded;
    private Vector3 velocity;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        //movement
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        //apply Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // if grounded and falling reset vertical velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}

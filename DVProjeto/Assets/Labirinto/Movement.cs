using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private float gravity = -9.81f;
    private float speed = 10f;
    private float groundDistance = 0.4f;
    private float jump = 1.5f;
    private bool isGrounded;
    



    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("Grounded", isGrounded);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("Grounded", false);
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (x == 0f && z == 0f)
        {
            animator.SetFloat("MoveSpeed", 0);
        }
        else
        {
            animator.SetFloat("MoveSpeed", speed);
        }

    }
}
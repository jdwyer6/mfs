using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    public float forceScale = 5f; // Adjust this value to control movement speed

    private Rigidbody rb;
    private Animator anim;

    public bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        canMove = true;
    }

    private void FixedUpdate()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            if(!canMove) return;
            // Rotation
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Animation
            anim.SetBool("IsMoving", true);

            // Apply movement using AddForce with a scaled force
            Vector3 force = moveDirection * moveSpeed * forceScale;
            rb.AddForce(force, ForceMode.Force);

        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}

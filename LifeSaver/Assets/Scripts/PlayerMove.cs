using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public int speedForce = 10;
    public int jumpForce = 10;
    public int maxSpeed = 5;

    public bool isGrounded = false;
    public float speed = 0;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            Move();
            Jump();
        }
        SpeedControl();
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * speedForce);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * speedForce);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-transform.right * speedForce);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * speedForce);
    }

    private void SpeedControl()
    {
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if(isGrounded)
        {
            if(rb.velocity.magnitude < 0.1)
                rb.velocity = Vector3.zero;
        }

        speed = rb.velocity.magnitude;
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}

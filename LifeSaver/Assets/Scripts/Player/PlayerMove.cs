using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public int moveSpeed = 5;
    public int jumpSpeed = 5;
    public float airMultiply = 0.4f;
    public bool isGrounded = false;
    public Transform Orientation;
    public float speed = 0;
    

    float vertical = 0;
    float horizontal = 0;
    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //IsGrounded();
        MoveInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            Move();

            if (Input.GetKey(KeyCode.Space) && isGrounded)
                Jump();

        }
        
    }

    void MoveInput()
    {
        horizontal = 0;
        vertical = 0;

        if (Input.GetKey(KeyCode.W))
            vertical = 1;
        if (Input.GetKey(KeyCode.S))
            vertical = -1;

        if (Input.GetKey(KeyCode.A))
            horizontal = -1;
        if (Input.GetKey(KeyCode.D))
            horizontal = 1;

        
    }

    private void Move()
    {
        Vector3 MoveDirection = Orientation.forward * vertical + horizontal * Orientation.right;
        
        if (isGrounded)
        {
            rb.AddForce(MoveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            rb.AddForce(MoveDirection.normalized * moveSpeed * 10f * airMultiply, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
    }

    private void SpeedControl()
    {
        if (rb.velocity.magnitude > moveSpeed)
        {
            Vector3 vector3 = new Vector3(rb.velocity.x, 0, rb.velocity.z).normalized * moveSpeed;
            vector3.y = rb.velocity.y;
            rb.velocity = vector3;
        }

        speed = rb.velocity.magnitude;
    }

    private void IsGrounded()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.up * -1, out hit, 1.1f);
        if (hit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded();
        isGrounded = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        IsGrounded();
    }

}

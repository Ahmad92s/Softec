using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;

    public float 
        walkSpeed,
        runSpeed, 
        jumpForce,
        downForce,
        turnSmoothTime;
    float turnSmoothVelocity;

    //Input
    private float horizontal, vertical;
    private Vector3 direction;

    //Movement
    internal bool isMoving, isGrounded, isRunning, jump;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0, vertical);

        //Walk
        if(direction.magnitude >= 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //Run
        if (isMoving && Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
        if (jump)
        {
            Jump();
        }

        rb.AddForce(new Vector3(0f, -downForce, 0f));
    }

    private void Move()
    {

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //Debug.Log(moveDir);

        if (isRunning)
        {
            rb.MovePosition(transform.position + (moveDir.normalized * runSpeed));
        }
        else if (isMoving)
        {
            rb.MovePosition(transform.position + (moveDir.normalized * walkSpeed));
        }
    }
    void Jump()
    {
        Debug.Log("here");
        jump = false;
        if (!isGrounded)
        {
            return;
        }
        Debug.Log("here2");

        rb.AddForce(new Vector3(0f, jumpForce, 0f));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isGrounded)
        {
            isGrounded = false;
        }
    }
}

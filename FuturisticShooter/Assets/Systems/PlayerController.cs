using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool moving = false;
    public float maxMoveSpeed;
    public float rampUpSpeedMovement;
    public float rampDownSpeedMovement;
    private float currentMovementSpeed;
    public float jumpForce;
    public bool strafe;
    public bool shooting;
    public bool isJumping;
    public Rigidbody rb;
    public float rampUpSpeedJump;
    public float jumpSpeedMultiplier;
    public Aimer aim;
    private void Awake()
    {
        maxMoveSpeed = maxMoveSpeed * 75;
        rampDownSpeedMovement = rampDownSpeedMovement * 75;
        rampUpSpeedMovement = rampUpSpeedMovement * 75;
        rampUpSpeedJump = rampUpSpeedMovement * jumpSpeedMultiplier;
    }



    public void Update()
    {
        if (!moving)
        {
            if (currentMovementSpeed > 0)
            {
                currentMovementSpeed -= rampDownSpeedMovement;
                if (currentMovementSpeed < 0)
                {
                    currentMovementSpeed = 0;
                }
            }

        }
    }

    public void Jump()
    {
        isJumping = true;
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    public void Move(Vector3 axis)
    {
        if (currentMovementSpeed < maxMoveSpeed)
        {
            if (isJumping)
            {
                currentMovementSpeed += rampUpSpeedJump * Time.deltaTime;
                if (currentMovementSpeed > maxMoveSpeed)
                {
                    currentMovementSpeed = maxMoveSpeed;
                }
            }
            else
            {
                currentMovementSpeed += rampUpSpeedMovement * Time.deltaTime;
                if (currentMovementSpeed > maxMoveSpeed)
                {
                    currentMovementSpeed = maxMoveSpeed;
                }
            }

        }
        if (strafe)
        {
            DoMove(axis, strafe);
        }
        else
        {
            DoMove(axis);
        }
    }

    void DoMove(Vector3 axis, bool strafe)
    {
        Vector3 velocity = transform.InverseTransformDirection(rb.velocity);
        velocity.z=axis.z*currentMovementSpeed;
        velocity.x=axis.x*currentMovementSpeed;
        velocity.y=rb.velocity.y;
        rb.velocity = transform.TransformDirection(velocity);
    }

    void DoMove(Vector3 axis)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}

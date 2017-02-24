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

    private void Awake()
    {
        maxMoveSpeed=maxMoveSpeed*75;
        rampDownSpeedMovement=rampDownSpeedMovement*75;
        rampUpSpeedMovement=rampUpSpeedMovement*75;
    }



    public void Update()
    {
        if(!moving&&!isJumping)
        {
            if(currentMovementSpeed>0)
            {
                currentMovementSpeed -= rampDownSpeedMovement;
                if(currentMovementSpeed<0)
                {
                    currentMovementSpeed=0;
                }
            }

        }
    }

    public void Jump()
    {
        isJumping=true;
        moving=false;
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    public void Move(Vector3 axis)
    {
        if(!isJumping)
        {
            if (currentMovementSpeed < maxMoveSpeed)
            {
                currentMovementSpeed += rampUpSpeedMovement * Time.deltaTime;
                if (currentMovementSpeed > maxMoveSpeed)
                {
                    currentMovementSpeed = maxMoveSpeed;
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

    }

    void DoMove(Vector3 axis, bool strafe)
    {
        rb.velocity=axis*currentMovementSpeed;
    }

    void DoMove(Vector3 axis)
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        isJumping=false;
    }
}

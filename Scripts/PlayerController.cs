using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmountLeft = 1f;
    [SerializeField] float torqueAmountRight = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float jumpForce = 15f;
    
    bool isGrounded;
    bool canMove = true;

    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector2D;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        isGrounded = true;
    }

    
    void Update()
    {
        if(canMove)
        {

            RotatePlayer();
            RespondToBoost();
            PlayerJump(); 

        }

    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }

        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmountLeft);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmountRight);
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
            
        }
    }
}

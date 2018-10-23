﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    Transform gunBarrel;

    private float jumpTimeCounter;
    public float jumpTime;
    bool isRaising;
    bool facingRight;
    bool jump;
    bool holdingJump;
    bool doubleJump;

    bool shoot;
    public GameObject leftBullet, rightBullet;

    int jumpCount = 0;
    

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gunBarrel = transform.Find("gunBarrel");
        facingRight = true;

    }

    void FixedUpdate()
    {
        if (!isGrounded && Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround))
        {
            jumpCount = 0;
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        

        moveInput = Input.GetAxisRaw("Horizontal");                      // moves character
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (jump)                                                        // if the jump key was pressed
        {
            Jump();                                                      // call jump fuction
            jump = false;                                                // no longer jumping
        }

        if (shoot)
        {
            Fire();
            shoot = false;
        }

        if (holdingJump)
        {
            if (isRaising)                                              // and if jumping
            {
                if (jumpTimeCounter > 0)                                // increase jumpheight
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                    //Debug.Log("Jump time counter: " + jumpTimeCounter);
                }
                else
                {
                    isRaising = false;
                }
            }
        }
        
    }

    void Update()
    {
        if (moveInput > 0 && !facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
        else if (moveInput < 0 && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }

        if (Input.GetButtonDown("Jump"))                                // if jump key is pressed
        {
            jump = true;
        }                                                               // holding jump is true
        if (Input.GetButtonUp("Jump"))
        {
            isRaising = false;
        }
        if (Input.GetButton("Jump"))
        {
            holdingJump = true;
        } else
        {
            holdingJump = false;
        }
        if (Input.GetButtonDown("Fire") && GameObject.FindGameObjectsWithTag("Bullet").Length < 5)
        {
            shoot = true;
        }
    }

    void Jump()
    {
        
        if(jumpCount < 2)                                           // if haven't jumped
        {
            jumpTimeCounter = jumpTime;
            isRaising = true;                                        // currently jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);     // do physics
            jumpCount++;
        }
    }
    void Fire()
    {
        if (facingRight)
        {
            Instantiate(rightBullet, gunBarrel.position, Quaternion.identity);
        }
        else if (!facingRight)
        {
            Instantiate(leftBullet, gunBarrel.position, Quaternion.identity);
        }
    }
}
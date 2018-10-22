using System.Collections;
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
    bool isJumping;
    bool facingRight;
    bool jump;
    bool holdingJump;
    bool doubleJump;

    int jumpCount = 0;
    

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gunBarrel = transform.Find("gunBarrel");

    }

    void FixedUpdate()
    {
        //Debug.Log("1st holding jump?: " + holdingJump);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCount = 0;
            //Debug.Log("resetting jumpcount: " + jumpCount);
            doubleJump = false;
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //Debug.Log("2nd holding jump?: " + holdingJump);
        if (jump)                                          // if the jump key was pressed
        {
            Jump();                                                      // call jump fuction
            jump = false;                                                // no longer jumping
        }
        //     this part is for the variable jump height
        if (Input.GetButton("Jump"))                                                 // if holding jump
        {
            if (isJumping)                                               // and if jumping
            {
                if (jumpTimeCounter > 0)                                 // increase jumpheight
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                    
                }
            }
            if (!holdingJump)
            {
                isJumping = false;
                
            }
        }
    }

    void Update()
    {
        if(moveInput > 0 && !facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        } else if(moveInput < 0 && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }

        if (Input.GetButtonDown("Jump"))                 // if jump key is pressed
        {
            jumpTimeCounter = jumpTime;
            jumpCount++;
            jump = true;
        }                                             // holding jump is true        
        
    }

    void Jump()
    {
        if(jumpCount == 0)                                           // if haven't jumped
        {
            isJumping = true;                                        // currently jumping
                                          // set jumptimer for the held jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);     // do physics
        } else if (jumpCount == 1)                      // if have jumped once
        {
            Debug.Log("DOUBLE JUMPING");
            
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Debug.Log("jumpcount: " + jumpCount);
    }
}

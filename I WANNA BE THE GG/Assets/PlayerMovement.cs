using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float h = 0f;
    bool jump = false;
    bool crouch = false;
    bool doubleJump = false;
    int jumpCount = 0;

    // Update is called once per frame
    void Update() {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        h = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            jump = true;
            jumpCount++;
            //Debug.Log("SINGLE JUMP:" + jumpCount);
        } else if (Input.GetButtonDown("Jump") && !controller.isGrounded() && jumpCount < 2)
        {
            doubleJump = true;
            jumpCount++;
            //Debug.Log("DOUBLE JUMP:" + jumpCount);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    
    void FixedUpdate()
    {
        //Debug.Log("JUMPCOUNT BEFORE MOVE:" + jumpCount);
        //Debug.Log("DOUBLEJUMP: " + doubleJump);
        //Debug.Log("JUMP: " + jump);
        controller.Move(h * Time.fixedDeltaTime, crouch, jump, doubleJump, jumpCount);

        jump = false;
        doubleJump = false;
        if (controller.isGrounded())
        {
            //Debug.Log("RESETING JUMP COUNT:" + jumpCount);
            jumpCount = 0;
        }
        
    }
}

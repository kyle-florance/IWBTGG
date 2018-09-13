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

    // Update is called once per frame
    void Update() {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        h = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && !jump)
        {
            jump = true;
        } else if (Input.GetButtonDown("Jump") && jump && !doubleJump)
        {
            doubleJump = true;
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
        controller.Move(h * Time.fixedDeltaTime, crouch, jump, doubleJump);

        jump = false;
        doubleJump = false;
        
        
    }
}

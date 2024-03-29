﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       

        if(joystick.Horizontal >= .2f){
            horizontalMove = runSpeed;
        }
        else if(joystick.Horizontal <= -.2f){
            horizontalMove = -runSpeed;
        }
        else{
            horizontalMove = 0f;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        float verticalMove = joystick.Vertical;


        if (verticalMove >= .5f){

            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (verticalMove <= -.5f)
        {
            crouch = true;
        }
        else{
            crouch = false;
        }
    }
    public void OnLanding(){

        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

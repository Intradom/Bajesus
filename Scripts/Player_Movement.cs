using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Control controller;
    public Animator animator;

    public float walk_speed = 40f;
    //public float run_speed_mult = 2f;

    private float horizontal_move = 0f;
    private bool jump = false;
    //private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal") * walk_speed; // * ( - 1 + run_speed_mult);

        /*
        bool sprinting = Input.GetButton("Sprint");
        if (sprinting)
        {
            horizontal_move *= run_speed_mult;
        }
        animator.SetBool("sprint", sprinting);
        */

        animator.SetFloat("speed", Mathf.Abs(horizontal_move));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", true);
        }

        /*
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        */
    }

    void FixedUpdate()
    {
        controller.Move(horizontal_move * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void on_landing()
    {
        animator.SetBool("jumping", false);
    }
}

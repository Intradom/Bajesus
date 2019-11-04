using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Control controller;
    public Animator animator;

    /* Movement */
    public float walk_speed = 20f;

    private float horizontal_move = 0f;
    private float speed_mult = 1f;
    private bool jump = false;
    //private bool crouch = false;

    /* Abilities */
    public Heal_base left_mouse_spawn;
    public GameObject right_mouse_spawn;
    public Heal_orb boost_source;
    public Transform shoot_location;
    public float heal_cd_seconds = 1.0f;
    public float orb_cd_seconds = 0.5f;
    public float boost_time_seconds = 0.5f;
    public float strong_boost_speed_mult = 3.0f;
    public float weak_boost_speed_mult = 1.5f;

    private Heal_base spawned_heal = null;
    private float heal_cd_timer = 0f;
    private float orb_cd_timer = 0f;
    private float boost_timer = 0f;
    private bool boosted = false;

    private void Start()
    {
        heal_cd_timer = heal_cd_seconds;
        orb_cd_timer = orb_cd_seconds;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timers
        heal_cd_timer += Time.deltaTime;
        orb_cd_timer += Time.deltaTime;

        // Check if boost runs out
        if (boosted)
        {
            //Debug.Log(speed_mult);
            if (boost_timer < boost_time_seconds) // still going
            {
                boost_timer += Time.deltaTime;
            }
            else // time expired
            {
                speed_mult = 1;
                animator.speed = speed_mult;
                boosted = false;
            }
        }

        // Movement
        horizontal_move = Input.GetAxisRaw("Horizontal") * walk_speed * speed_mult; // * ( - 1 + run_speed_mult);
        //Debug.Log(horizontal_move);
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

        // Abilities
        if (Input.GetButtonDown("Mouse Left"))
        {
            if (heal_cd_timer >= heal_cd_seconds)
            {
                if (spawned_heal != null)
                {
                    spawned_heal.Destroy();
                }

                Vector3 spawn_loc = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                spawned_heal = Instantiate(left_mouse_spawn, new Vector2(spawn_loc.x, spawn_loc.y), Quaternion.identity);
                heal_cd_timer = 0f;
            }
        }

        if (Input.GetButtonDown("Mouse Right"))
        {

        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontal_move * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("jumping", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            bool strong_boost = collision.GetComponent<Heal_orb>().ready;

            boosted = true;
            boost_timer = 0f;
            speed_mult = strong_boost ? strong_boost_speed_mult : weak_boost_speed_mult;
            animator.speed = speed_mult;

            collision.GetComponent<Heal_orb>().Destroy();
        }
    }
}

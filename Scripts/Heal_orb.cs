using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Heal_orb : MonoBehaviour
{
    public Animator animator;

    public bool ready = false;

    public void OnReady()
    {
        ready = true;
        animator.SetBool("spin_ready", true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

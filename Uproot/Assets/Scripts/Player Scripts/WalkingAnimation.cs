using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    private Animator runningAnimator;
    private Vector2 movement;

    void Start()
    {
        runningAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f || movement.y != 0f)
        {
            runningAnimator.SetTrigger("PlayWhileRunning");
        }
        else
        {
            runningAnimator.SetTrigger("DontPlay");
        }
    }
}

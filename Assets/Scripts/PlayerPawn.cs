using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        UpdateAnimations();
    }

    //method for animations
    public void UpdateAnimations()
    {
        if (rb.velocity.y > 0 && rb.velocity.x <= 0)
        {
            sr.flipX = true;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y > 0 && rb.velocity.x >= 0)
        {
            sr.flipX = false;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y < 0 && rb.velocity.x <= 0)
        {
            sr.flipX = true;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y < 0 && rb.velocity.x >= 0)
        {
            sr.flipX = false;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.x < 0 && rb.velocity.y == 0)
        {
            sr.flipX = true;
            anim.Play("Player1Walk2");
        }
        else if (rb.velocity.x > 0 && rb.velocity.y == 0)
        {
            sr.flipX = false;
            anim.Play("Player1Walk2");
        }
        else
        {
            anim.Play("Player1Idle");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.U2D;

public class Pawn : MonoBehaviour
{
    //for pawn's animator
    public Animator anim;
    //for pawn's Rigidbody2D
    public Rigidbody2D rb;
    //game object's sprite renderer
    public SpriteRenderer sr;

    //for paw speed
    public float speed;
    //for pawn jump height
    public float jumpForce;
    //float for grounding distance
    public float groundingDistance;

    [Header("Animation Thresholds")]
    //float for jump animation threshold
    public float yThreshold;
    //float for walk animation threshold
    public float xThreshold;
    


    void Start()
    {
        //get components of game object
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateAnimations();
    }

    //**************************
    //TODO fix walk animation
    //**************************

    //method for animations
    public void UpdateAnimations() 
    {
        if (rb.velocity.x > 0 && rb.velocity.y == 0)
        {
            sr.flipX = false;
            anim.Play("Player1Walk2");
        }
        else if (rb.velocity.x < 0 && rb.velocity.y == 0)
        {
            sr.flipX = true;
            anim.Play("Player1Walk2");
        }
        else if (rb.velocity.y > 0 && rb.velocity.x < 0)
        {
            sr.flipX = true;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y > 0 && rb.velocity.x > 0)
        {
            sr.flipX = false;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y < 0 && rb.velocity.x < 0)
        {
            sr.flipX = true;
            anim.Play("Player1Jump");
        }
        else if (rb.velocity.y < 0 && rb.velocity.x > 0)
        {
            sr.flipX = false;
            anim.Play("Player1Jump");
        }
        else
        {
            anim.Play("Player1Idle");
        }
    }

    public void Move(Vector3 direction)
    {
        //move the rigidbody by x input multiplied by speed. pass y axis 0
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, 0);
    }

    public void Jump() 
    {
        if (IsGrounded()) 
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }

    public bool IsGrounded() 
    {
        //check if we are grounded
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, groundingDistance);
        if (hitInfo.collider.gameObject.CompareTag("Ground"))
        {
            return true;
        }

        else 
        {
            return false;
        }
    }
}

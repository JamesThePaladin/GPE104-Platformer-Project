using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    //to hold the moveInput
    private float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        if (pawn == null)
        {
            pawn = GameManager.instance.player.GetComponent<Pawn>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement inputs
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveInput = Input.GetAxis("Horizontal") * pawn.sprintBoost;
            pawn.Move(new Vector2(moveInput, 0));
        }

        else
        {
            moveInput = Input.GetAxis("Horizontal");
            pawn.Move(new Vector2(moveInput, 0));
        }

        //jump
        if (Input.GetButtonDown("Jump") && pawn.currentJumps > 0)
        {
            pawn.currentJumps--;
            pawn.Jump();
        }
        else if (Input.GetButtonDown("Jump") && pawn.currentJumps == 0 && pawn.IsGrounded()) 
        {
            pawn.Jump();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
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
            if (Input.GetKey(KeyCode.A))
            {
                pawn.Move(-pawn.transform.right * pawn.sprintBoost);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pawn.Move(pawn.transform.right * pawn.sprintBoost);
            } 
        }

        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                pawn.Move(-pawn.transform.right);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pawn.Move(pawn.transform.right);
            } 
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.Jump();
        }
    }
}


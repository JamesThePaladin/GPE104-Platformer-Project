using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : Controller
{
    // Update is called once per frame
    void Update()
    {
        //move pawn forward
        pawn.Move(pawn.transform.right);

        if (pawn == null) 
        {
            GetComponent<WalkerController>().enabled = false;
        }
    }
}

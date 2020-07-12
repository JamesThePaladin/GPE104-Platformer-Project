﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WalkerPawn : Pawn
{
    /// <summary>
    /// Walker platform patrol is courtesy of Blackthornprod
    /// I have adapted it to work with my controller
    /// </summary>
    /// 
    //to hold the walker's death explosion
    public GameObject explosion;
    //transform for ground detection
    public Transform groundDetect;
    //float for the distance of the detection raycast
    public float detectDistance;
    //bool for moving right
    public bool movingRight = true;
    //int for number of points walkers are worth
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundDetection();
    }
    public void GroundDetection()
    {
        RaycastHit2D detectInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, detectDistance);
        if (detectInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if game object is not an asteroid
        if (!other.gameObject.CompareTag("Enemy"))
        {
            //lower the number of asteroids
            GameManager.instance.SendMessage("ScorePoints", points);
            //make an explosion
            anim.Play("DeathAnim");
            //destroy the asteroid
            Destroy(this.gameObject, 3f);
        }
    }
}
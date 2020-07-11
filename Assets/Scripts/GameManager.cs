using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //variable that holds this instance of the GameManager

    public GameObject player; //variable for player
    private Transform playerTf; //variable for player's transform

    public int score; //public player score for testing
    public int lives; //lives for player
    public int coinAmount; //amount of coins player has
    private int sceneTime; //for time on current level
    public Text scoreText; //reference to score text
    public Text livesText; //reference to lives text
    public Text coinText; //reference to coins amount text
    public Text timeText; //to hold the time in current scene

    public GameObject fadeScreen; //for our fade screen effect

    public enum GameStates 
    {
        MainMenu,
        LevelOne,
        LevelTwo,
    }

    //to hold our current game state
    public GameStates currentState; 

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) // if instance is empty
        {
            instance = this; // store THIS instance of the class in the instance variable
            DontDestroyOnLoad(this.gameObject); //keep this instance of game manager when loading new scenes
        }
        else
        {
            Destroy(this.gameObject); // delete the new game manager attempting to store itself, there can only be one.
            Debug.Log("Warning: A second game manager was detected and destrtoyed"); // display message in the console to inform of its demise
        }

        if (player == null) //if player slot is empty
        {
            player = GameObject.FindWithTag("Player"); //fill it with player
        }

        score = 0;
        scoreText.text = " x" + score;
        lives = 3;
        livesText.text = " x" + lives;
        sceneTime = 0;
        timeText.text = " " + 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) //if player slot is empty
        {
            player = GameObject.FindWithTag("Player"); //fill it with player
        }

        //********************************
        //TODO: Make gamestate pseudo
        //********************************

        //switch (currentState)
        //{
        //    default:
        //        //set game state to main menu
        //        //load main menu scene
        //        break;
        //}
    }

    //takes in points from other objects and adds it to the player's score
    public void ScorePoints(int addPoints)
    {
        //add points to player score
        score += addPoints;
        //update score text in UI
        scoreText.text = " x" + score;
    }

    public void LoseLife()
    {
        //minus a life
        lives--;
        //update lives in UI
        livesText.text = " x" + lives;

        //if lives are less than or equal to 0 game over
        if (lives <= 0)
        {
            //ask to restart?
        }
    }

    public void CollectCoins(int addCoins)
    {
        //add points to player score
        coinAmount += addCoins;
        //update score text in UI
        coinText.text = "" + coinAmount;
    }
}

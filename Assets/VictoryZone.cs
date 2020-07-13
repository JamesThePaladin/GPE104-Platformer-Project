﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Victory!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Wait();
        }
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(3f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}

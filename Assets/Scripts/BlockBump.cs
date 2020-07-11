using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Block Bump script courtesy of valiant YouTuber, Username Simkon
/// they posted it in the comments of a tutorial for everyone to use
/// </summary>
public class BlockBump : MonoBehaviour
{

    public float xPos;
    public float yPos;
    public float zPos;

    IEnumerator OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        transform.GetComponent<Collider>().isTrigger = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(xPos, yPos + 0.2F, zPos);
            yield return new WaitForSeconds(0.08F);
            transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(0.25F);
            transform.GetComponent<Collider>().isTrigger = true;
        }
    }

    // Use this for initialization
    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Block Bump script courtesy of valiant YouTuber, Username Simkon
/// they posted it in the comments of a tutorial for everyone to use
/// </summary>
public class BlockDestroy : MonoBehaviour
{
    //floats for block's axi
    public float xPos;
    public float yPos;
    //float for block "destruction"
    float waiting = 0.02F;

    IEnumerator OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.transform.position = new Vector3(xPos, yPos + 0.1F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos + 0.2F);
            yield return new WaitForSeconds(waiting);
            transform.GetComponent<Collider>().isTrigger = false;
            this.transform.position = new Vector3(xPos, yPos + 0.3F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos + 0.4F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos - 0.1F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos - 0.6F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos - 1.6F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos - 2.6F);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(xPos, yPos - 4.0F);
            yield return new WaitForSeconds(0.25F);
            transform.GetComponent<Collider>().isTrigger = true;
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
    }


}

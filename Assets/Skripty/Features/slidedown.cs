using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidedown : MonoBehaviour
{
    
    
    public GameObject Player;
    public Rigidbody2D rb;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            rb.gravityScale = 50;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            rb.gravityScale = 5;
        }
    }
}

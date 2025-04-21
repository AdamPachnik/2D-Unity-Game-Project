using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCombat Player = collision.GetComponent<PlayerCombat>();
         if (Player != null)
         {
             Player.TakeDamage(20);
             Destroy(gameObject);
         }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

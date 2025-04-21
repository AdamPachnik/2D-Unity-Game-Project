using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator anim;
    public Rigidbody2D rb;

   
 
   
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
       
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("isDead", true);


        StartCoroutine(Waitin());

    }
    IEnumerator Waitin()
    {
        yield return new WaitForSeconds(4/5);
        doThis();
    }
    void doThis()
    {
        
        rb.bodyType = RigidbodyType2D.Static;

        GetComponent<Collider2D>().enabled = false;
       
    }
      
   
}

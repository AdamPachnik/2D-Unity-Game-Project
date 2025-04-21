using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{


    public GameObject DetectAttack;
    public GameObject ChasingPlayer;
    public GameObject StopMove;
    public GameObject ShurikenHitBox;
    public GameObject Block;
    public Transform player;
    public Transform HitBox;
    public AudioSource hurtSound1;
    public Animator anim;
    public Rigidbody2D rb;
    public LayerMask playerLayers;

    [HideInInspector] public bool inRange;
    [HideInInspector] public bool flip;

    public float difference;
    public bool inDifference;
    public bool inDetection;
    public float speed = 2f;
    public float attackRange = 2f;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        inDetection= false;
        currentHealth = maxHealth;      
    }

        void Update()
        {           
            if (inRange)
            {
                Attack();
            }
            else if(!inRange)
            {  
                anim.SetBool("Attack", false);
            }

            if (inDetection)
            {
                walk();                
            }
           else if (!inDetection)
            {
                
                anim.SetBool("Walk", false);            
            }
               
           
                Flip();
            
    }
    void walk()
    {  
        anim.SetBool("Attack", false); 
        anim.SetBool("Walk", true);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (player.position.x > transform.position.x)
        {
            rotation.y = 180;
        }
        else
        {
            rotation.y = 0;
        }
        transform.eulerAngles = rotation;
    }

    void Attack()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }
    
    public void attackPlayer() // spustí sa eventom v animácie
    {

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(HitBox.position, attackRange, playerLayers);

        foreach (Collider2D Player in hitPlayer)
        {
            Player.GetComponent<PlayerCombat>().TakeDamage(20);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (HitBox == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(HitBox.position, attackRange);
    }


    public void TakeDamage(int damage) // spustený v scripte PlayerCombat
    {
        hurtSound1.Play();
        currentHealth -= damage;
        ChasingPlayer.SetActive(false);
        DetectAttack.SetActive(false);
        StopMove.SetActive(false);
        anim.SetTrigger("Hurt");
        inRange = false;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Waitingg());
        }
    }
    IEnumerator Waitingg()
    {
        anim.SetBool("isDead", false);
        anim.SetBool("Attack", false);
        yield return new WaitForSeconds(7/4);
        doThis1();
    }
    void doThis1()
    {
        ChasingPlayer.SetActive(true);
        DetectAttack.SetActive(true);
        StopMove.SetActive(true);
        if (Math.Abs(player.position.x - transform.position.x) > 1.6) // cca range DetectAttack collidera
        {
            player = player.transform;
        }
        else
        {
            inDetection = false;
            inRange = true;
            player = player.transform;
            Flip();
        }
    }
   
    void Die()
    {
        Block.SetActive(false);
        anim.SetBool("isDead", true);
        inRange = false;
        player = null;
        GetComponent<NewEnemy>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        ChasingPlayer.SetActive(false);
        DetectAttack.SetActive(false);
        StopMove.SetActive(false);
        ShurikenHitBox.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }
    
  
}

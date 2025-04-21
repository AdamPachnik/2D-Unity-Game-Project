using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Transform HitBox;
    public GameObject detectattack;
    public BoxCollider2D sproutCollider;
    public BoxCollider2D detectPlayer;
    public SpriteRenderer SpriteRenderer;
    public Transform target;
    public LayerMask playerLayers;
    public float speed = 2f;
    float maxHealth = 100;
    float currentHealth;
    public bool move;
    public float attackRange;
    void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
        sproutCollider.isTrigger = true;
        move = false;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (move)
        {
            Move();
        }

    }
        
    //--------------------MOVEMENT
    public void Move() 
    {
        anim.SetBool("Move", true);
        anim.SetBool("Attack", false);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        
    }
    //--------------------COMBAT
    void AttackPlayer() 
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(HitBox.position, attackRange, playerLayers);
        foreach (Collider2D Player in hitPlayer)
        {
            Player.GetComponent<PlayerCombat>().TakeDamage(10);
        }
    }
    //---------HITBOX
    private void OnDrawGizmosSelected()
    {
        if (HitBox == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(HitBox.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        detectattack.SetActive(false);
        anim.SetBool("Attack", false);
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
           
            anim.SetBool("Dead", false);
            detectattack.SetActive(true);
        }

    }


    void Die()
    {
        anim.SetBool("Dead", true);
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Sprout>().enabled = false;
        sproutCollider.enabled = false;
        detectPlayer.enabled = false;


    }

}
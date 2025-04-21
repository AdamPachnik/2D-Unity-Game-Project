using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WizardCombat : MonoBehaviour
{


    public GameObject DetectAttack;
    public GameObject ChasingPlayer;
    public GameObject StopMove;
    public GameObject ShurikenHitBox;
    public GameObject Gem;
    public GameObject Block;
    public Transform player;
    public Transform HitBox;
 //   public AudioSource hurtSound1, hurtSound2;
    public Animator anim;
    public Rigidbody2D rb;
    public HealthBar healthbar;
    public LayerMask playerLayers;

    [HideInInspector] public bool inRange;
    [HideInInspector] public bool flip;
    public bool b = true;
    public bool inDetection;
    public float speed = 2f;
    public float attackRange = 2f;
    public int maxHealth = 400;
    int currentHealth;

    void Start()
    {
        inDetection = true;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        if (inRange)
        {
            Attack();
        }
        else if (!inRange)
        {
            anim.SetBool("Attack2", false);
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
        anim.SetBool("Attack2", false);
        anim.SetBool("Walk", true);
        float step = speed * Time.deltaTime;
        Vector2 vector2 = Vector2.MoveTowards(transform.position, player.position, step);
        transform.position = vector2;

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
        anim.SetBool("Attack2", true);
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
       /* hurtSound1.Play();
        hurtSound2.Play();*/
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        ChasingPlayer.SetActive(false);
        DetectAttack.SetActive(false);
        StopMove.SetActive(false);
        anim.SetTrigger("Hurt");
        b = false;
        inRange = false;
        inDetection = false;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Waiting());
        }
    }
    IEnumerator Waiting()
    {
        anim.SetBool("isDead", false);
        anim.SetBool("Attack2", false);
        yield return new WaitForSeconds(1);
        doThis();
    }
    void doThis()
    {
        ChasingPlayer.SetActive(true);
        DetectAttack.SetActive(true);
        StopMove.SetActive(true);
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (Math.Abs(player.position.x - transform.position.x) > 1.6) // cca range DetectAttack collidera
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Walk", true);
            player = player.transform;
            inDetection = true;
            b = true;
        }
        else
        {
            inDetection = false;
            inRange = true;
            b = true;
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
        GetComponent<WizardBehaviour>().enabled = false;
        GetComponent<Wizard>().enabled = false;
        ChasingPlayer.SetActive(false);
        DetectAttack.SetActive(false);
        StopMove.SetActive(false);
        rb.gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        //   ShurikenHitBox.SetActive(false);
        Gem.SetActive(true);
        GetComponent<WizardCombat>().enabled = false;
    }


}

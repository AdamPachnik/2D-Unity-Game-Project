using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;
    public Transform player;
    public BoxCollider2D skeleton;
    public Transform HitBox;
    public LayerMask playerLayers;
    public bool run;

    public float speed = 2f;
    public float attackRange = 2f;
    void Start()
    {
        run = true;
    }

    
    void Update()
    {
        if (run)
        {
        Walk();
        }
        else
        {
            anim.SetBool("Attack", true);
        }
        Flip();
    }
    void Walk()
    {
        anim.SetBool("Attack", false);
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

        anim.SetBool("isDead", true);
        GetComponent<Skeleton>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
    }

}


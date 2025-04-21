using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGuardian : MonoBehaviour
{

    public GameObject DetectAttack;
    public GameObject ChasingPlayer;
    public GameObject StopMove;
    public GameObject Block;
    public AudioSource hurt;
    public AudioSource hurt2;

    [HideInInspector] public Transform target;
    [HideInInspector] public Transform target2;
    [HideInInspector] public bool inRange;
    [HideInInspector] public bool flip;
    public Animator anim;
    public Transform PlayerAfterHurt;
    public Transform HitBox;
    public Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
    public LayerMask playerLayers;

    int currentHealth;
    public float speed = 2f;
    public float attackRange = 1f;
    public int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (inRange)
        {
            Attack();
        }
        else if (!inRange)
        {
            anim.SetBool("Attack", false);
        }

        if (target != null)
        {
            walk();
        }
        else if (target == null)
        {
            anim.SetBool("Walk", false);
        }

        if (flip)
        {
            FlipInStopMove();
        }
    }
    void walk()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", true);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (target.position.x > transform.position.x)
        {
            rotation.y = 180;
        }
        else
        {
            rotation.y = 0;
        }
        transform.eulerAngles = rotation;
    }

    public void FlipInStopMove()
    {
        Vector3 rotation = transform.eulerAngles;
        if (target2.position.x > transform.position.x)
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
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        inRange = false;
        StartCoroutine(CoolDown2());
    }
    IEnumerator CoolDown2()
    {
        yield return new WaitForSeconds(1);
        if (rbPlayer.bodyType == RigidbodyType2D.Static)
        {
            inRange = false;
        }
        else
        {
            if ((PlayerAfterHurt.position.x) < (transform.position.x - 1.6) || (PlayerAfterHurt.position.x) > (transform.position.x + 1.6))
            {
                inRange = false;
            }
            else
            {
                inRange = true;
            }
        }
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
        hurt.Play();
        hurt2.Play();
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
            anim.SetBool("isDead", false);
            anim.SetBool("Attack", false);
            StartCoroutine(Waitingg());
        }
    }
    IEnumerator Waitingg()
    {
        anim.SetBool("Attack", false);
        yield return new WaitForSeconds(7 / 4);
        doThis1();
    }
    void doThis1()
    {
        ChasingPlayer.SetActive(true);
        DetectAttack.SetActive(true);
        StopMove.SetActive(true);
        if ((PlayerAfterHurt.position.x) < (transform.position.x - 1.6) || (PlayerAfterHurt.position.x) > (transform.position.x + 1.6)) // cca range DetectAttack collidera
        {
            target = PlayerAfterHurt.transform;
        }
        else
        {
            target = null;
            inRange = true;
            target2 = PlayerAfterHurt.transform;
            FlipInStopMove();
        }
    }

    void Die()
    {
        Block.SetActive(false);
        anim.SetBool("isDead", true);
        inRange = false;
        target = null;
        GetComponent<CircleCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        ChasingPlayer.SetActive(false);
        DetectAttack.SetActive(false);
        StopMove.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<NewEnemy>().enabled = false;
    }


}

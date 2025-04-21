using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTrap : MonoBehaviour
{
    public Animator anim;
    public Transform HitBox;
    public GameObject detectattack;
    public BoxCollider2D enemyTrapCollider;
    public LayerMask playerLayers;
    float currentHealth;
    float maxHealth = 100;
    public float attackRange;
    public bool ready;
   
    void Start()
    {
        ready = false;
        currentHealth = maxHealth;
    }

    void AttackPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(HitBox.position, attackRange, playerLayers);

        foreach (Collider2D Player in hitPlayer)
        {
            Player.GetComponent<PlayerCombat>().TakeDamage(10);
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

    public void TakeDamage(int damage)
    {
         currentHealth -= damage;
         detectattack.SetActive(false);
         anim.SetBool("stopAttack", true);
         anim.SetTrigger("Hurt");
         if (currentHealth <= 0)
         {
             Die();
         }
         else
         {
             anim.SetBool("isDead", false);
         }
       
    }
 

    void Die()
    {
            anim.SetBool("isDead", true);
            GetComponent<enemyTrap>().enabled = false;
            enemyTrapCollider.enabled = false;
    }
    
}
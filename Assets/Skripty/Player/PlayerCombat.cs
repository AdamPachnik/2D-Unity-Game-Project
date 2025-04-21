using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Animator chest;
    public bool vCheste;
    public Transform HitBox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask barrelLayers;
    public LayerMask enemyTrapLayers;
    public LayerMask huntressLayers;
    public LayerMask sproutLayers;
    public LayerMask skeletonLayers;
    public LayerMask wizardLayers;
    public int MaxHealth = 100;
    public Rigidbody2D rb;
    public bool CanHit;
    int currentHealth;
    [HideInInspector] public bool jevovoziku;
    public bool zaciatok;

    public GameObject HealthBar;
    public GameObject enemy;
    public GameObject Score;
    public GameObject Menu;
    public GameObject PauseMenu;
    public HealthBar healthbar;
    public AudioSource hit,hurt;
    private void Start()
    { 
        currentHealth = MaxHealth;
        CanHit = true;
        healthbar.SetMaxHealth(MaxHealth);
        jevovoziku = false;
        vCheste = false;
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && CanHit && !jevovoziku)
        {
            anim.SetTrigger("Attack");
   
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        // Debug.Log(PlayerPrefs.GetInt("LastScene"));
       // Debug.Log(PlayerPrefs.GetInt("coiny"));
    }
   
    public void attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitBox.position, attackRange, enemyLayers);
        Collider2D[] hitEnemyTraps = Physics2D.OverlapCircleAll(HitBox.position, attackRange, enemyTrapLayers);
        Collider2D[] hitHuntress = Physics2D.OverlapCircleAll(HitBox.position, attackRange, huntressLayers);
        Collider2D[] hitSprout = Physics2D.OverlapCircleAll(HitBox.position, attackRange, sproutLayers);
        Collider2D[] hitSkeleton = Physics2D.OverlapCircleAll(HitBox.position, attackRange, skeletonLayers);
        Collider2D[] hitWizard = Physics2D.OverlapCircleAll(HitBox.position, attackRange, wizardLayers);

        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<NewEnemy>().TakeDamage(20);
        }
        foreach (Collider2D enemyTrap in hitEnemyTraps)
        {
            enemyTrap.GetComponent<enemyTrap>().TakeDamage(100);
        }
        foreach (Collider2D enemyTrap in hitHuntress)
        {
            enemyTrap.GetComponent<Weapon>().TakeDamage(20);
        }
        foreach (Collider2D Sprout in hitSprout)
        {
            Sprout.GetComponent<Sprout>().TakeDamage(50);
        }
        foreach (Collider2D Skeleton in hitSkeleton)
        {
            Skeleton.GetComponent<Skeleton>().TakeDamage(50);
        }
        foreach (Collider2D Wizard in hitWizard)
        {
            Wizard.GetComponent<WizardCombat>().TakeDamage(20);
        }
    }
    public void Explosionn()
    {
        Collider2D[] hitBarrel = Physics2D.OverlapCircleAll(HitBox.position, attackRange, barrelLayers);

        foreach (Collider2D Barrel in hitBarrel)
        {
            Barrel.GetComponent<Explosion>().Eexplosion();
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
    public void Heal(int heal)
    {
        currentHealth += heal;
        healthbar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        hurt.Play();
        anim.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            anim.SetBool("isDead", false);
            CanHit = false;
            rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(AfterHit());
        }
    }
    public void Die()
    {
        PlayerPrefs.SetInt("coiny", 0);
        anim.SetBool("isDead", true);
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 0f;
        GetComponent <PlayerMovement>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        StartCoroutine(Dies());
    }
    public void Pause()
    {
        HealthBar.SetActive(false);
        Score.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator Dies()
    {
        yield return new WaitForSeconds(3);
        HealthBar.SetActive(false);
        Score.SetActive(false);
        Menu.SetActive(true);

    }
    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(1);
        CanHit = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void HurtSound()
    {
        hit.Play();
    }

}

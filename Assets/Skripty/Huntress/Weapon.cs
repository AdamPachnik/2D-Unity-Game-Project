using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public GameObject shurikenHitBox;
    public Animator anim;
    public Rigidbody2D rb;
    bool canShoot; 
    int currentHealth;
    public int maxHealth = 60;
    private void Start()
    {
        canShoot = true;
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootCoolDown());
        }

    }

    IEnumerator ShootCoolDown()
    {
        canShoot = false;
        anim.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(2);
        anim.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(2);
        canShoot = true;
    }
    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
    public void TakeDamage(int damage) // spustený v scripte PlayerCombat
    {
        canShoot = false;
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            anim.SetBool("isDead", false);
            anim.SetBool("Shoot", false);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        anim.SetBool("Shoot", false);
        yield return new WaitForSeconds(7 / 4);
        canShoot = true;
    }
    void Die()
    {       
        anim.SetBool("isDead", true); ;
        rb.bodyType = RigidbodyType2D.Static;
        shurikenHitBox.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Weapon>().enabled = false;
    }
}
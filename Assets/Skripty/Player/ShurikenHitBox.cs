using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenHitBox : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            if (Enemy.tag == "Enemy") 
            {
            Enemy.GetComponent<NewEnemy>().TakeDamage(30);
            }
            else if ( Enemy.tag == "enemyTrap")
            {
                GameObject.Find("Player").GetComponent<Shuriken>().HitEnemy = true;
            }
            else
            {
             Enemy.GetComponent<Weapon>().TakeDamage(30);
            }
            GameObject.Find("Player").GetComponent<Shuriken>().HitEnemy = true;
        }
        if (collision.gameObject.CompareTag("Arcane"))
        {
            if (Enemy.tag == "Enemy")
            {
                Enemy.GetComponent<NewEnemy>().TakeDamage(50);
            }
            else
            {
               // Enemy.GetComponent<Weapon>().TakeDamage(50);
            }
            GameObject.Find("Player").GetComponent<Shuriken>().HitEnemy = true;
        }
    }



}

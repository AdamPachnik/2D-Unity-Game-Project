using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdetectattack : MonoBehaviour
{
    public GameObject Player;
    public GameObject enemyTrap;
    public Animator anim;
    private void Start()
    {
        anim.SetBool("stopAttack", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("stopAttack", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("stopAttack", true);
        }
    }
}

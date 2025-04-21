using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dettectAttack : MonoBehaviour
{
    public GameObject Player;
    public GameObject Sprout;
    public Animator anim;
    private void Start()
    {
        anim.SetBool("Attack", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Sprout.GetComponent<Sprout>().move = false;
            anim.SetBool("Attack", true);
            anim.SetBool("Move", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Sprout.GetComponent<Sprout>().move = true;
        }
    }
}

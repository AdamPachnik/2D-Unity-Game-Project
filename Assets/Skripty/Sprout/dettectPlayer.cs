using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dettectPlayer : MonoBehaviour
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
            Sprout.GetComponent<Sprout>().move = true;
            Sprout.GetComponent<Sprout>().sproutCollider.isTrigger = false;
            Sprout.GetComponent<Sprout>().SpriteRenderer.sortingOrder = 20;
            Sprout.GetComponent<Sprout>().rb.bodyType = RigidbodyType2D.Dynamic;   
        }
    }
}

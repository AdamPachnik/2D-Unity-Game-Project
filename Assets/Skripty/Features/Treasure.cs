using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int sortingOrder = 0;
    private SpriteRenderer sprite;
    bool vCheste = false;
    public Animator chest;
    public BoxCollider2D chestCollider;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && vCheste)
        {
            chest.SetTrigger("Open");
            chestCollider.enabled = false;
            sprite.sortingOrder = sortingOrder;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vCheste = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           vCheste = false;

        }
    }
    

}

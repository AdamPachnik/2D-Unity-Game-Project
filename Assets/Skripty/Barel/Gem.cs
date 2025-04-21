using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameObject.Find("Player").GetComponent<PlayerCombat>().Heal(20);
            gem.SetActive(false);
        }
    }

   
}



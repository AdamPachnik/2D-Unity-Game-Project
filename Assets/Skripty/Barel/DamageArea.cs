using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerCombat>().TakeDamage(50);
            gameObject.SetActive(false);
        }
    }
  
}

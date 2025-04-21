using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;

public class ArcaneEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCombat Player = collision.GetComponent<PlayerCombat>();
        if (Player != null)
        {
            Player.TakeDamage(20);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURNOFF : MonoBehaviour
{
    public GameObject DAMAGEBARRELS2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DAMAGEBARRELS2.SetActive(false);
        }
    }
}

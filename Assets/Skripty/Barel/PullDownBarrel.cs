using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullDownBarrel : MonoBehaviour
{
    public GameObject Barrel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Barrel.SetActive(true);
        }
    }
}

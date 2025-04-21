using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    public GameObject wizard;
    public GameObject WizardDetection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wizard.GetComponent<Wizard>().stop = true;          
        }
    }
   
}


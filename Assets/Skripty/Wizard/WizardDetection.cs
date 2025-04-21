using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDetection : MonoBehaviour
{
    public GameObject wizard;
    public GameObject healthbar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (wizard.GetComponent<Wizard>().wave <= 3)
            {
            wizard.GetComponent<Wizard>().inDetection = true;
            healthbar.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (wizard.GetComponent<Wizard>().wave <= 3)
            {
                wizard.GetComponent<Wizard>().inDetection = false;
            }
        }
    }

}

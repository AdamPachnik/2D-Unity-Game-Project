using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardChasingPlayer : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Enemy.GetComponent<WizardCombat>().b == true)
        {
            Enemy.GetComponent<WizardCombat>().inDetection = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Enemy.GetComponent<WizardCombat>().inDetection = false;
        }
    }
}

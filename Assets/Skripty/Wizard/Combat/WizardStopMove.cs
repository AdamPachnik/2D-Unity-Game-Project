using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStopMove : MonoBehaviour
{
    public GameObject DettectAttack;
    public GameObject ChasingPlayer;
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Enemy.GetComponent<WizardCombat>().inDetection = false;
            Enemy.GetComponent<WizardCombat>().inRange = false;
            ChasingPlayer.SetActive(false);
            DettectAttack.SetActive(false);
            Enemy.GetComponent<WizardCombat>().flip = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            Enemy.GetComponent<WizardCombat>().flip = false;
            Enemy.GetComponent<WizardCombat>().inDetection = true;
            DettectAttack.SetActive(true);
            ChasingPlayer.SetActive(true);

        }
    }
}

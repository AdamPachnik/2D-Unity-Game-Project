using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDetectAttack : MonoBehaviour
{

    public GameObject ChasingPlayer;
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ChasingPlayer.SetActive(false);
            Enemy.GetComponent<WizardCombat>().inRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            ChasingPlayer.SetActive(true);
            Enemy.GetComponent<WizardCombat>().inRange = false;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public GameObject DettectAttack;
    public GameObject ChasingPlayer;
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Enemy.GetComponent<NewEnemy>().inDetection = false;
            Enemy.GetComponent<NewEnemy>().inRange = false;
            ChasingPlayer.SetActive(false);
            DettectAttack.SetActive(false);
            Enemy.GetComponent<NewEnemy>().flip = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            Enemy.GetComponent<NewEnemy>().flip = false;
            Enemy.GetComponent<NewEnemy>().inDetection = true;
            DettectAttack.SetActive(true);
            ChasingPlayer.SetActive(true);

        }
    }
}

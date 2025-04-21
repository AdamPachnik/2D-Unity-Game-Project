using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayer : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Enemy.GetComponent<NewEnemy>().inDetection= true;        
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Enemy.GetComponent<NewEnemy>().inDetection = false;
        }
    }
}

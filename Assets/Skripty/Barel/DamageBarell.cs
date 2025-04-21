using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBarell : MonoBehaviour
{
    public GameObject DamageArea;  
    float y = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
          DamageArea.SetActive(true);
         GameObject.Find("Barrel").GetComponent<Explosion>().Eexplosion();
            StartCoroutine(TurnOff());
        }
    }
    IEnumerator TurnOff()
    {
        //Debug.Log(y);
        yield return new WaitForSeconds(y);
        DamageArea.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcaneGem : MonoBehaviour
{
    public GameObject gem;
    public GameObject Shuriken;
    public GameObject EffectIcon;
    public Image FIll;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameObject.Find("Player").GetComponent<Shuriken>().enabled = true;
            Shuriken.SetActive(false);
            EffectIcon.SetActive(true);
            FIll.color = new Color32(42,0,90,255);
            gem.SetActive(false);
        }
    }


}



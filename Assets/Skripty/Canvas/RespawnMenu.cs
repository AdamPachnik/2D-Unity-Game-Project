using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RespawnMenu : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject Coins;
    public GameObject RechargeBar;
    public GameObject MainMenuDeath;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            HealthBar.SetActive(false);
            RechargeBar.SetActive(false);
            Coins.SetActive(false);
            MainMenuDeath.SetActive(true);
            PlayerPrefs.SetInt("coiny", 0);

        }
    }
  

}

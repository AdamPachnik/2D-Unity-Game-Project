using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounterCoins : MonoBehaviour
{
    public Text coinText;
    public AudioSource coinSound;
    int currentCoins = 0;
    private void Start()
    {
          currentCoins = PlayerPrefs.GetInt("coiny");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("coiny", currentCoins + 1);
            coinSound.Play();
        }
          currentCoins = PlayerPrefs.GetInt("coiny");
    }
   private void Update()
    {
        coinText.text = currentCoins.ToString();
    }

}

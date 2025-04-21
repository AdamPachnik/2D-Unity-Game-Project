using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCoins : MonoBehaviour
{
    
    public Text coinText;
    private void Start()
    {
        coinText.text = PlayerPrefs.GetInt("coiny").ToString();
       
    }
    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("coiny").ToString();
    }

  

}


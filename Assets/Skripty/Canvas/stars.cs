using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stars : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    int coins;

    void Update()
    {
        coins = PlayerPrefs.GetInt("coiny");
        if (coins <= 8)
        {
            starOne();
        }
        else if (coins <= 16 && coins > 8)
        {
           StartCoroutine(starTwo());
        }
        else if (coins <= 24 && coins > 16)
        {
            StartCoroutine(starThree());
        }
        else if (coins <= 32 && coins > 24)
        {
            StartCoroutine(starFour());
        }
        else if (coins > 32)
        {
            StartCoroutine(starFive());
        }
    }

    public void starOne()
    {
       
        star1.SetActive(true);
    }   
    IEnumerator starTwo()
    {
        star1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star2.SetActive(true);
    }
    IEnumerator starThree()
    {
        star1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star3.SetActive(true);
    }
    IEnumerator starFour()
    {
        star1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star3.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star4.SetActive(true);
    }
    IEnumerator starFive()
    {
        star1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star3.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star4.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        star5.SetActive(true);
    }
}

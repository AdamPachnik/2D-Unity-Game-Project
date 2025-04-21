 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechargeBar : MonoBehaviour
{
    public Slider Recharge;
    private int maxCharge = 100;
    private int currentCharge;

    public static RechargeBar instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentCharge = maxCharge;
        Recharge.maxValue = maxCharge;
        Recharge.value = maxCharge;
    }

   public void UseCharge(int amount)
    {
        if (currentCharge - amount >= 0)
        {
            currentCharge -= amount;
            Recharge.value = currentCharge;
            StartCoroutine(RechargeRegen());
        }
        else
        {
            Debug.Log("Not enough charge");
        }
    }
    private IEnumerator RechargeRegen()
    {
        while (currentCharge < maxCharge)
        {
            currentCharge += maxCharge / 100;
            Recharge.value = currentCharge;
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("Player").GetComponent<Shuriken>().canShoot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcane : MonoBehaviour
{
    public GameObject arcane;
    Rigidbody2D arcanerb;
    GameObject arcaneGo;
    float power = 650;
    public bool canShoot = true;
    public bool HitEnemy;

    void Start()
    {
        HitEnemy = false;

    }
    void Update()
    {

        if (Input.GetKeyDown("q") && canShoot )
        {
          //  RechargeBar.instance.UseCharge(100);
            StartCoroutine(Throw());
            canShoot = false;
        }
        if (HitEnemy)
        {
            Destroy(arcaneGo);
            HitEnemy = false;
        }

    }

    IEnumerator Throw()
    {
        if (transform.localScale.x < 0)
        {
            arcaneGo = Instantiate(arcane, new Vector2(transform.position.x - 0.4f, transform.position.y), Quaternion.identity);
            arcanerb = arcaneGo.GetComponent<Rigidbody2D>();
            arcanerb.AddForce(new Vector2(-power, arcanerb.velocity.y));
        }
        else
        {
            arcaneGo = Instantiate(arcane, new Vector2(transform.position.x + 0.4f, transform.position.y), Quaternion.identity);
            arcanerb = arcaneGo.GetComponent<Rigidbody2D>();
            arcanerb.AddForce(new Vector2(power, arcanerb.velocity.y));
        }
        arcanerb.AddTorque(100);
        yield return new WaitForSecondsRealtime(3);
        Destroy(arcaneGo);

    }
}

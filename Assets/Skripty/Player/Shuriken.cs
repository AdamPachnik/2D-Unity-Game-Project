using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public GameObject shuriken;
    Rigidbody2D shurikenrb;
    GameObject shurikenGo;
    float power = 650;
    public bool canShoot = true;
    public bool HitEnemy;

    void Start()
    {
        HitEnemy = false;

    }
    void Update()
    {
    
        if (Input.GetKeyDown("q") && canShoot)
        {
            RechargeBar.instance.UseCharge(100);
            StartCoroutine(Throw());
            canShoot = false;
        }
        if (HitEnemy)
        {
            Destroy(shurikenGo);
            HitEnemy = false;
        }

    }

    IEnumerator Throw()
    {
        if (transform.localScale.x < 0)
        {
        shurikenGo = Instantiate(shuriken, new Vector2(transform.position.x - 0.4f, transform.position.y), Quaternion.identity);
        shurikenrb = shurikenGo.GetComponent < Rigidbody2D>();
        shurikenrb.AddForce(new Vector2(-power, shurikenrb.velocity.y));
        }
        else
        {
        shurikenGo = Instantiate(shuriken, new Vector2(transform.position.x + 0.4f, transform.position.y), Quaternion.identity);
        shurikenrb = shurikenGo.GetComponent<Rigidbody2D>();
        shurikenrb.AddForce(new Vector2(power, shurikenrb.velocity.y));
        }
        shurikenrb.AddTorque(100);
        yield return new WaitForSecondsRealtime(3);
        Destroy(shurikenGo);
        
    }
}

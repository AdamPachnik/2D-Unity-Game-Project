using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardArcane : MonoBehaviour
{
    public GameObject shuriken;
    public Animator anim;
    Rigidbody2D arcanerb;
    GameObject arcaneGo;
    float power = 650;
    public bool canShoot = true;
    public bool HitEnemy;

    void Start()
    {
        HitEnemy = false;
        canShoot = true;
    }
    void Update()
    {

        if (canShoot)
        {
            /* StartCoroutine(Throw());*/
            anim.SetBool("Spell", true);
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            canShoot = false;
        }
 

    }

    public IEnumerator Throw()
    {
        if (transform.localScale.x < 0)
        {
            arcaneGo = Instantiate(shuriken, new Vector2(transform.position.x - 0.4f, transform.position.y-0.4f), Quaternion.identity);
            arcanerb = arcaneGo.GetComponent<Rigidbody2D>();
            arcanerb.AddForce(new Vector2(-power, arcanerb.velocity.y));
        }
        else
        {
            arcaneGo = Instantiate(shuriken, new Vector2(transform.position.x + 0.4f, transform.position.y-0.4f), Quaternion.identity);
            arcanerb = arcaneGo.GetComponent<Rigidbody2D>();
            arcanerb.AddForce(new Vector2(power, arcanerb.velocity.y));
        }
        arcanerb.AddTorque(100);
        StartCoroutine(ShootCoolDown());
        anim.SetBool("Spell", false);
        yield return new WaitForSecondsRealtime(6);
        
    }
    IEnumerator ShootCoolDown()
    {
        canShoot = false;
        yield return new WaitForSecondsRealtime(1);
        canShoot = true;
    }
}

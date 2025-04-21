using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


public class WizardBehaviour : MonoBehaviour
{
    public GameObject Wizard;
    public Animator anim;
    public Rigidbody2D rb;
    public Transform point;
    public GameObject detection;
    public bool sendingDone;
    public bool runAway;
    public bool ArcaneOrSkeletons;
    void Start()
    {
        sendingDone= false;
        runAway = false;
        ArcaneOrSkeletons = true;
    }

    void Update()
    {
        if (sendingDone)
        {
            GetComponent<Wizard>().enabled = false;
            GetComponent<WizardArcane>().enabled = false;
            GetComponent<WizardCombat>().enabled = true;
            StartCoroutine(Waiting());
        }
        if (runAway)
        {
            Physics2D.IgnoreLayerCollision(9,19);
            Physics2D.IgnoreLayerCollision(9,20);
            Physics2D.IgnoreLayerCollision(9,8);
            Physics2D.IgnoreLayerCollision(9, 0);
            WalkTopoint();
        }
    }
    IEnumerator Waiting()
    {
        
        yield return new WaitForSeconds(5);
        sendingDone = false;
        runAway = true;
        GetComponent<WizardCombat>().inDetection = true;
        GetComponent<WizardCombat>().enabled = false;
    }
    IEnumerator Arcane()
    {

        yield return new WaitForSeconds(6);
        anim.SetBool("Spell", false);
        GetComponent<WizardArcane>().canShoot = true;
        sendingDone = true;
        ArcaneOrSkeletons = false;
    }

    void WalkTopoint()
    {
        if (Math.Abs(transform.position.x - point.transform.position.x) <= 2)
        {
            
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
            FlipBack();
            sendingDone = false;
            runAway = false;
            Physics2D.IgnoreLayerCollision(9, 19, false);
            Physics2D.IgnoreLayerCollision(9, 20, false);
            Physics2D.IgnoreLayerCollision(9, 8, false);
            Physics2D.IgnoreLayerCollision(9, 0, false);
            if (ArcaneOrSkeletons)
            {
            GetComponent<WizardArcane>().enabled = true;
            GetComponent<Wizard>().enabled = false;  
            StartCoroutine(Arcane());
            }
            if(!ArcaneOrSkeletons)
            {
            GetComponent<Wizard>().enabled = true;
            detection.SetActive(true);
            }

        }
        else
        {
            Flip();
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
            float step = 8f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, point.position, step);
        }


    }
    public void FlipBack()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = 0;
        transform.eulerAngles = rotation;
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = 180;
        transform.eulerAngles = rotation;
    }
}

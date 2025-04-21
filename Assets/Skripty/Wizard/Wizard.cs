using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;
    public Transform point;

    public GameObject WizardDetection;
    public GameObject Skeletons;

    public float speed = 4f;
    public bool inDetection;
    public bool chasing;
    public bool stop;
    public int wave;

    void Start()
    {
        WizardDetection.SetActive(true);
        inDetection = false;
        stop = false;   
        wave = 0; 
    }

   
    void Update()
    {
        if (inDetection)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
        }
        if (stop)
        {
            WizardDetection.SetActive(false);
            inDetection = false;
        }

    }


    void SendSkeleton()
    {
        if (wave == 3)
        {
            Skeletons.transform.GetChild(0).gameObject.SetActive(true);
            Skeletons.transform.GetChild(0).gameObject.transform.parent = null;
            WizardDetection.SetActive(false);
            inDetection = false;
            StartCoroutine(Waiting());
        }
        else
        {
            Skeletons.transform.GetChild(0).gameObject.SetActive(true);
            Skeletons.transform.GetChild(0).gameObject.transform.parent = null;
            wave += 1;
        }
        
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        wave = 0;
        GetComponent<WizardBehaviour>().sendingDone = true;
        GetComponent<WizardBehaviour>().ArcaneOrSkeletons = true;
    }



}

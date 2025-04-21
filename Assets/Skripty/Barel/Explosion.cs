using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Explosion : MonoBehaviour
{

 
    public ParticleSystem particle;
    public GameObject barel;
    public AudioSource sound;
    public void Eexplosion()
    {     
        particle.Play();
        sound.Play();
        barel.SetActive(false);        
    }
   
}

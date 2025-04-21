using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 1f;
    public AudioMixer audiomix;

    
    void Start()
    {
        AudioSource.Play();
    }

    
    void Update()
    {
        AudioSource.volume = musicVolume;
        
    }
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}

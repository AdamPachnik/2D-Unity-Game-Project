using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicChangerPause : MonoBehaviour
{
    public AudioMixer Music;
    public AudioMixer SFX;
    public Slider SFXslider;
    public Slider MusicSlider;
    public void SetVolume (float volume)
    {
        Music.SetFloat("VolumeMusic", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        SFX.SetFloat("SFX", volume);
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("SFX", SFXslider.value);
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
    }
    private void Start()
    {
        SFXslider.value = PlayerPrefs.GetFloat("SFX");
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
    }
}

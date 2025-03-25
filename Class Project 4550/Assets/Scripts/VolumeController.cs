using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControler : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sfxSlider;
    public AudioSource bgmSource;
    public AudioSource sfxSource;


    void Start()
    {
        volumeSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;


        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
        
        Debug.Log("Initial volume: " + bgmSource.volume);
        Debug.Log("Initial SFX volume: " + sfxSource.volume);

    }

    public void ChangeVolume(float volume)
    {
            Debug.Log("Volume Changed to: " + volume);
            bgmSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        Debug.Log("SFX Volume Changed to: " + volume);
        sfxSource.volume = volume;
    }

    public void PlaySFX()
    {
        sfxSource.Play();
    }

    public void Update()
    {
        Debug.Log("Current SFX Volume: " + sfxSource.volume);
    }

}

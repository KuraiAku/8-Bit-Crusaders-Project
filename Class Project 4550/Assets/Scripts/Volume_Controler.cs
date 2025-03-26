using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControler : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sfxSlider;
    public AudioSource bgmSource;
    public List<AudioSource> sfxSources = new List<AudioSource>();

    private AudioSource sfxSource; // Single reference for an SFX source

    void Start()
    {
        volumeSlider.value = bgmSource.volume;

        if (sfxSources.Count > 0)
        {
            sfxSource = sfxSources[0]; // Assign first SFX source
            sfxSlider.value = sfxSource.volume;
        }


        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);

        Debug.Log("Initial volume: " + bgmSource.volume);
        if (sfxSource != null) Debug.Log("Initial SFX volume: " + sfxSource.volume);
    }

    public void ChangeVolume(float volume)
    {
        Debug.Log("Volume Changed to: " + volume);
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        Debug.Log("SFX Volume Changed to: " + volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);

        foreach (AudioSource sfx in sfxSources)
        {
            sfx.volume = volume;
        }
    }

    public void PlaySFX()
    {
        if (sfxSources.Count > 0)
        {
            sfxSources[0].Play(); // Play the first available SFX
        }
    }
}
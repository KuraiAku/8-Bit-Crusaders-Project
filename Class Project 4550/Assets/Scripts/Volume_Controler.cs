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


    void Start()
    {
        volumeSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("SFX"))
        {
            AudioSource audio = obj.GetComponent<AudioSource>();
            if (audio != null)
            {
                sfxSources.Add(audio);
                audio.volume = sfxSlider.value;
            }
        }


        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
        
        Debug.Log("Initial volume: " + bgmSource.volume);
        Debug.Log("Initial SFX volume: " + sfxSource.volume);

    }

    public void ChangeVolume(float volume)
    {
            Debug.Log("Volume Changed to: " + volume);
            bgmSource.volume = volume;
            PlayerPrefs.SetFloat("BGMVolume", volume)
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
        if (sfxSlider != null)
        {
            sfxSlider.volume = sfxSlider.value;
            sfx.Play();
        }
    }
}

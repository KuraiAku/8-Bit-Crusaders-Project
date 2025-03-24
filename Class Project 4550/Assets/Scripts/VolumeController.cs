using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControler : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource bgmSource;
    public AudioSource sfxSource;


    void Start()
    {
        volumeSlider.value = bgmSource.volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    }

    public void ChangeVolume(float volume)
    {
            Debug.Log("Volume Changed to: " + volume);
            bgmSource.volume = volume;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControler : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource bgmSource;


    void Start()
    {
        volumeSlider.value = bgmSource.volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    }

    public void ChangeVolume(float volume)
    {
            bgmSource.volume = volume;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]private AudioMixer mixer;
    [SerializeField]private Slider slider;
    [SerializeField]private AudioSource myMusic;

    void Start()
    {
        // Slider Value is always starting at 0.75 out of 1
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    private void Update()
    {
        //Updating the master volume
        myMusic.volume = slider.value;
    }
    public void SetLevel(float sliderValue)
    {
        //Setting the Volume and adding to PlayerPref
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    /* The next 2 methods are used for Voice control to indicate increase(+) or decrease(-) depending 
        on method called. The methods determine the slider value which overall determines the 
        volume of music being played. */
    public void Volume(float volume)
    {
        slider.value += volume;
    }
    public void PlayOneShot(AudioClip clip)
    {// Play just one sound
        if (clip)
        {
            myMusic.PlayOneShot(clip);
        }
    }
}

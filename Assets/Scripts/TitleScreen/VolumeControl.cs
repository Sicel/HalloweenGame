using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    public float multiplier = 1;

    void Start() {
        float vol = PlayerPrefs.GetFloat("volume", 1);
        PlayerPrefs.SetFloat("volume", vol);

        if (slider != null)
            slider.value = PlayerPrefs.GetFloat("volume");

        if (audioSource != null)
            audioSource.volume = PlayerPrefs.GetFloat("volume") * multiplier;
    }

    public void SetVolume(float value) {
        PlayerPrefs.SetFloat("volume", value);
    }

    void Update() {
        if (audioSource != null)
            audioSource.volume = PlayerPrefs.GetFloat("volume") * multiplier;
    }

    void onApplicationQuit() {
        PlayerPrefs.Save();
    }
}

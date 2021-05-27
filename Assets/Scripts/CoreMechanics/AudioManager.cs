using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    
    //TODO: apply volume to audio to rest of the game.
    //TODO: save audio for when the game is restarted and have the volume 'catch up'.

    [SerializeField] string volumeChannel;
    [SerializeField] string mutedChannel;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] Toggle audioToggle;
    bool disableToggle;
    float multiplier = 30;
    float mutedVolume = .25f;

    void Awake() {
        audioSlider.onValueChanged.AddListener(HandleSliderValueChange);
        audioToggle.onValueChanged.AddListener(HandleToggleValueChange);
    }

    void Start() {
        audioSlider.value = PlayerPrefs.GetFloat(volumeChannel, audioSlider.value);
    }

    void OnDisable() {
        PlayerPrefs.SetFloat(volumeChannel, audioSlider.value);
    }

    void HandleSliderValueChange(float value) {

        mixer.SetFloat(volumeChannel, Mathf.Log10(value) * multiplier);
        disableToggle = true;
        audioToggle.isOn = audioSlider.value > audioSlider.minValue;
        disableToggle = false;
    }

    void HandleToggleValueChange(bool isEnabled) {
        if (disableToggle) return;
        if (!isEnabled){
            PlayerPrefs.SetFloat(mutedChannel, audioSlider.value);
        }
        audioSlider.value = isEnabled ? PlayerPrefs.GetFloat(mutedChannel, .25f) : audioSlider.minValue;
    }

}
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeControl : MonoBehaviour
{
    public Slider VolumeSlider;
    public float initialVolume = 0.5f;

    public MenuPauseController menuPauseController;

    void Start(){
        VolumeSlider.value = initialVolume;
        AdjustGlobalVolume(initialVolume);
    }

    public void OnSliderValueChanged(){
        menuPauseController.UpdateImageVolume(VolumeSlider.value);
        AdjustGlobalVolume(VolumeSlider.value);
    }

    void AdjustGlobalVolume(float adjustmentFactor){
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach(AudioSource audiosource in audioSources)
            audiosource.volume = adjustmentFactor;
    }

    
}

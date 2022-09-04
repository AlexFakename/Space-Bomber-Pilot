using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSliderController : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sFXVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicVolumeSlider.value = FindObjectOfType<Options>().GetMusicVolume();
        sFXVolumeSlider.value = FindObjectOfType<Options>().GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        AudioControllerMusic audioControllerMusic = FindObjectOfType<AudioControllerMusic>();
        audioControllerMusic.SetVolume(musicVolumeSlider.value);
    }

    public float GetMusicSlider() { return musicVolumeSlider.value; }
    public float GetSFXSlider() { return sFXVolumeSlider.value; }
}

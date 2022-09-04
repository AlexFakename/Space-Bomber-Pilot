using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private float musicVolume = 0.1f;
    private float sFXVolume = 0.1f;
    private const float MAXVOL = 1f;
    private const float MINVOL = 0f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadOptions();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetMusicVolume(float volume)
    {
        if (volume <= MAXVOL && volume >= MINVOL) { musicVolume = volume; }
        else { Debug.LogError("Music Volume out of range"); }
    }
    public void SetSFXVolume(float volume)
    {
        if (volume <= MAXVOL && volume >= MINVOL) { sFXVolume = volume; }
        else { Debug.LogError("SFX Volume out of range"); }
    }
    public void SaveOptionsBackButton() { SetMusicVolume(FindObjectOfType<OptionsSliderController>().GetMusicSlider()); SetSFXVolume(FindObjectOfType<OptionsSliderController>().GetSFXSlider()); SaveOptions(); }

    public void SaveOptions() { SaveSystem.SaveOptions(this); }
    public void LoadOptions() { OptionsFile file = SaveSystem.LoadOptions(); musicVolume = file.musicVolume; sFXVolume = file.sFXVolume; }


    public float GetMusicVolume() { return musicVolume; }
    public float GetSFXVolume() { return sFXVolume; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionsFile
{
    public float musicVolume;
    public float sFXVolume;

    public OptionsFile(Options options)
    {
        musicVolume = options.GetMusicVolume();
        sFXVolume = options.GetSFXVolume();
    }
}

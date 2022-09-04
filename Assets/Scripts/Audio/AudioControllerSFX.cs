using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerSFX : MonoBehaviour
{
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = FindObjectOfType<Options>().GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVolume(float volume) { myAudioSource.volume = volume; }
}



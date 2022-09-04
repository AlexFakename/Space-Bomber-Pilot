using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerMusic : MonoBehaviour
{
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = FindObjectOfType<Options>().GetMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVolume(float volume) { myAudioSource.volume = volume; }
}

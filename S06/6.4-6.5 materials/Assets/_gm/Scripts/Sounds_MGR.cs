using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_MGR : MonoBehaviour
{

    public AudioSource _musicAudioSource;
    public AudioClip _musicClip;

    private void Start()
    {
        PlayMusic();
    }


    void PlayMusic(){
        _musicAudioSource.clip = _musicClip;
        _musicAudioSource.Play();
        _musicAudioSource.volume = 0.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] audios;
    void Start()
    {
        audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aud in audios)
        {
            if (aud.playOnAwake)
            {
                aud.volume = PlayerPrefs.GetFloat("BGMVol");
                
            }
            else
            {
                aud.volume = PlayerPrefs.GetFloat("SFXVol");
            }
        }
    }
}

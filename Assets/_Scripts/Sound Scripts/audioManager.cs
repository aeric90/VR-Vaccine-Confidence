using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    public AudioClip[] sounds;

    void Awake()
    {
        instance = this;
    }

    public void Play(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                GetComponent<AudioSource>().PlayOneShot(sounds[i]);
            }
        }
    }

    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void Pause_Audio(bool value)
    {
        if (value)
        {
            GetComponent<AudioSource>().Pause();
        }
        else 
        {
            GetComponent<AudioSource>().UnPause();
        }
    }
}
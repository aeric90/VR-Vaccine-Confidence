using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_controller : MonoBehaviour
{
    public static music_controller instance;
    private bool fade_value = false;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(fade_value)
        {
            float music_volume = GetComponent<AudioSource>().volume;
            
            if(music_volume > 0.0f)
            {
                music_volume -= 0.001f;
                GetComponent<AudioSource>().volume = music_volume;
            } else
            {
                GetComponent<AudioSource>().Stop();
                fade_value = false;
            }
        }
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.15f;
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

    public void Trigger_Fade()
    {
        fade_value = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    public Sound[] sounds;

    void Awake()
<<<<<<< Updated upstream
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play (string name)
=======
>>>>>>> Stashed changes
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name) s.source.Play();
        }
    }
<<<<<<< Updated upstream
=======

    public void Play (string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].source.Play();
            }
        }
    }

    public void Change (string name, AudioClip replacement)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].clip = replacement;
            }
        }
    }
>>>>>>> Stashed changes
}

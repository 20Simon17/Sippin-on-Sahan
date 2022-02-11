//gjord av Theo
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManeger : MonoBehaviour
{

    public Sound[] sound;


    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sound)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name);
        s.source.Play();
    }

}


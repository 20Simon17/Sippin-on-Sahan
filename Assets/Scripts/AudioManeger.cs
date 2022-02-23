//gjord av Theo
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManeger : MonoBehaviour
{

    public Sound[] sound; // ansluter till scripted Sound


    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sound) 
        {

            s.source = gameObject.AddComponent<AudioSource>(); // gör så att man kan referera till audiomaneger 
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name); // gör der möjligt att hitta ljudet som man vill spela och spelar det
        s.source.Play();
    }

}


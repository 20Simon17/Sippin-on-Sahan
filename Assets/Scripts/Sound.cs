using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    //skriven av Theo

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;// gör så att man kan ändra volymen från 0 - 1
    [Range(1f, 3f)]
    public float pitch;// gör så att man kan ändra picchen mellan 1 - 3

    [HideInInspector]
    public AudioSource source;
}
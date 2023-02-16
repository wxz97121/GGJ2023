using UnityEngine.Audio;
using System;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }
    void Start()
    {
        Play("Theme");
    }
    public void Play(string name, bool playFromStart = true)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.volume = 1;
        if (playFromStart || !s.source.isPlaying)
            s.source.Play();

    }
    public void Stop(string name, bool setVolume = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        if (setVolume)
        {
            s.source.volume = 0;
        }
        else
        {
            s.source.Stop();
        }

    }

}

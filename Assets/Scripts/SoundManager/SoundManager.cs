using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : SingletonMono<SoundManager>
{
    //public Sound[] sounds;
    public SoundScriptable[] scriptableSounds;
    [SerializeField]
    string namesound = null;
    private void Awake()
    {       
        foreach(SoundScriptable s in scriptableSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play(namesound);
    }

    public void Play(string name)
    {
        SoundScriptable s = Array.Find(scriptableSounds, sound => sound.naming == name);      
        s.source.Play();            
    }
    public void Stop(string name)
    {
        SoundScriptable s = Array.Find(scriptableSounds, sound => sound.naming == name);
        s.source.Stop();
    }
}

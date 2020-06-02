using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSound",menuName = "ForRagnarok/Sound")]
public class SoundScriptable : ScriptableObject
{
    public string naming;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume;

    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sounds", menuName = "AudioSounds", order = 1)]
public class Audio : ScriptableObject
{
    public AudioClip[] sounds;

    public float volume;
}

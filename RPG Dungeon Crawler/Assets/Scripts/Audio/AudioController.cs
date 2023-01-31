using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public void PlayAudio(AudioSource audioSource, Audio tracks)
    {
        audioSource.PlayOneShot(tracks.sounds[Random.Range(0, tracks.sounds.Length)]);
    }
}

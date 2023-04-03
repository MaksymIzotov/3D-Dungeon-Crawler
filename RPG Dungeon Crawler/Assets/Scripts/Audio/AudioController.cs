using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public void PlayAudio(AudioSource audioSource, Audio tracks)
    {
        if (tracks != null)
            audioSource.PlayOneShot(tracks.sounds[Random.Range(0, tracks.sounds.Length)], tracks.volume);
    }
}

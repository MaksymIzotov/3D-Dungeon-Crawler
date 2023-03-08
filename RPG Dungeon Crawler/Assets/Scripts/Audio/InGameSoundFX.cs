using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundFX : MonoBehaviour
{
    #region Singleton Init
    public static InGameSoundFX Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, 0.5f);
    }
}

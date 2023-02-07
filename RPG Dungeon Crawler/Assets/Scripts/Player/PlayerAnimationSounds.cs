using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
    private AudioSource source;

    [Header("Potion")]

    [SerializeField] private AudioClip swallow;
    [SerializeField] private AudioClip potionOpen;

    [Space(10)]
    [Header("Healing")]

    [SerializeField] private AudioClip healing;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Swallow()
    {
        source.PlayOneShot(swallow, 1);
    }

    private void PotionOpen()
    {
        source.PlayOneShot(potionOpen, 1);
    }

    private void Healing()
    {
        source.PlayOneShot(healing, 0.3f);
    }
}

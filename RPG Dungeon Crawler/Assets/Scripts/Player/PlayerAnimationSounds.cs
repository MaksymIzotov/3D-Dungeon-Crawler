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

    [Space(10)]
    [Header("Fireball")]

    [SerializeField] private AudioClip fireball;

    [Space(10)]
    [Header("Bomb")]

    [SerializeField] private AudioClip bombThrow;

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

    private void Fireball()
    {
        source.PlayOneShot(fireball, 0.3f);
    }

    private void BombThrow()
    {
        source.PlayOneShot(bombThrow, 1f);
    }
}

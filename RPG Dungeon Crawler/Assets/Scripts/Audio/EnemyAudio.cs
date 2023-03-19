using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : AudioController
{
    public Audio Footsteps;
    public Audio Attack;
    public Audio AttackMissed;
    public Audio AttackAbove;
    public Audio SpecialHit;

    private AudioSource audioSource;
    [SerializeField] private bool isWalkingLooped;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Walk()
    {
        if (Footsteps == null) { return; }

        if (isWalkingLooped)
        {
            audioSource.loop = true;
            audioSource.clip = Footsteps.sounds[0];   
            audioSource.Play();
        }
        else
        {
            PlayAudio(audioSource, Footsteps);
        }
    }

    public void PlaySpecialHit()
    {
        PlayAudio(audioSource, SpecialHit);
    }

    public void PlayAttack()
    {
        PlayAudio(audioSource, Attack);
    }

    public void PlayAttackMissed()
    {
        PlayAudio(audioSource, AttackMissed);
    }

    public void PlayAttackAbove()
    {
        PlayAudio(audioSource, AttackAbove);
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}

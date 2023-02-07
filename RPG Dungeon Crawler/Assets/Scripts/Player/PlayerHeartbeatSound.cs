using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartbeatSound : MonoBehaviour
{
    [SerializeField] private Audio clips;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void UpdateAudio(float maxHp, float currentHp)
    {
        float amount = currentHp / (maxHp / 100);

        if (amount <= 10)
        {
            if (source.clip == clips.sounds[0]) { return; }

            source.clip = clips.sounds[0];
            source.Play();
            return;
        }
        if(amount <= 20)
        {
            if (source.clip == clips.sounds[1]) { return; }

            source.clip = clips.sounds[1];
            source.Play();
            return;
        }  
        if(amount <= 25)
        {
            if (source.clip == clips.sounds[2]) { return; }

            source.clip = clips.sounds[2];
            source.Play();
            return;
        }

        source.Stop();
        source.clip = null;
    }
}

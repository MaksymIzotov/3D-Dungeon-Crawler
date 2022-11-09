using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestroyer : MonoBehaviour
{
    private void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        Destroy(gameObject, main.duration + main.startLifetimeMultiplier);
    }
}

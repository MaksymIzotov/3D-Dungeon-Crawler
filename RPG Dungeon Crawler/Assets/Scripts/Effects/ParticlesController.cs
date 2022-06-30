using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public GameObject particles;

    public void SpawnParticles()
    {
        GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(effect, effect.GetComponent<ParticleSystem>().main.startLifetime.constant);
    }
}

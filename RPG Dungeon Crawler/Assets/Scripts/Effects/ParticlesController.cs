using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public GameObject explosionParticles;

    public GameObject burnParticles;

    public void SpawnExplosionParticles()
    {
        GameObject effect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(effect, effect.GetComponent<ParticleSystem>().main.startLifetime.constant);
    }

    public void SpawnBurnParticles(Transform enemy, float burnDuration, float damage)
    {
        Transform pos = enemy.Find("FX");

        GameObject burn = Instantiate(burnParticles, pos);
        burn.GetComponent<BurnController>().burnDamage = damage;
        var main = burn.GetComponent<ParticleSystem>().main;
        main.duration = burnDuration;
        burn.GetComponent<ParticleSystem>().Play();
    }
}

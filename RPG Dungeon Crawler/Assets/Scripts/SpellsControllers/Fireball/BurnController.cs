using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnController : MonoBehaviour
{
    public float burnDamage;

    GameObject enemy;
    private void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        StartCoroutine(DestroyObject(main.duration + main.startLifetimeMultiplier));
        enemy = transform.root.gameObject;
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        while (true)
        {
            if (enemy.GetComponent<IDamagable>()?.IsDead() == true) { StopAndDestroy(1); break; }

            enemy.GetComponent<IDamagable>().TakeDamage(burnDamage, null);
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator DestroyObject(float timer)
    {
        yield return new WaitForSeconds(timer);

        StopAndDestroy(1);
    }

    private void StopAndDestroy(float destroyTime)
    {
        var main = GetComponent<ParticleSystem>().main;
        main.maxParticles = 0;

        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            var mainChild = particle.main;
            mainChild.maxParticles = 0;
        }

        AudioFader.Instance.Fade(GetComponent<AudioSource>(), destroyTime, 0);
        Destroy(gameObject, destroyTime);
    }
}

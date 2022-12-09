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
        Destroy(gameObject, main.duration + main.startLifetimeMultiplier);
        enemy = transform.root.gameObject;
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        while (true)
        {
            if (enemy.GetComponent<EnemyHealthController>() == null) { break; }

            enemy.GetComponent<IDamagable>().TakeDamage(burnDamage, null);
            yield return new WaitForSeconds(1f);
        }
    }
}

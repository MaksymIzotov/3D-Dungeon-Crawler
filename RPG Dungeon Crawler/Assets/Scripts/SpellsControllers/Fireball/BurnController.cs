using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnController : MonoBehaviour
{
    public float burnDamage;

    GameObject enemy;
    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
        enemy = transform.parent.gameObject;
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        while (true)
        {
            enemy.GetComponent<IDamagable>().TakeDamage(burnDamage);
            yield return new WaitForSeconds(1f);
        }
    }
}

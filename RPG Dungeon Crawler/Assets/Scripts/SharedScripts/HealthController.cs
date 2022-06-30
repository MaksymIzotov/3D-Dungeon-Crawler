using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Health properties;

    private float hp;

    private void Start()
    {
        SetValues();
    }

    private void Update()
    {
        HealthRegen();
    }

    private void HealthRegen()
    {
        if (hp >= properties.healthPoints) { return; }

        hp += properties.healthRegen * Time.deltaTime;
    }


    public void TakeDamage(float damage)
    {
        float actualDamage = damage - (damage / 100 * properties.defence);
        hp -= actualDamage;

        //Do effects

        if (hp <= 0)
            Die();
    }


    private void Die()
    {

    }

    private void SetValues()
    {
        hp = properties.healthPoints;
    }
}

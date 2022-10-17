using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour, IDamagable
{
    public Health properties;
    public UnityEvent onDeath;

    private float hp;
    [HideInInspector] public bool isDead;
    private void Start()
    {
        SetValues();
    }

    private void Update()
    {
        HealthRegen();
    }

    public void HealthRegen()
    {
        if (hp >= properties.healthPoints) { return; }

        hp += properties.healthRegen * Time.deltaTime;
    }


    public void TakeDamage(float damage)
    {
        float actualDamage = damage - (damage / 100 * properties.defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.ShowDamage(actualDamage, transform, transform.localScale.y);

        if (hp <= 0)
            Die();
    }


    public void Die()
    {
        Destroy(GameObject.Find("Model/FX"));

        isDead = true;
        GetComponent<EnemyAnimationController>().Die();
        onDeath.Invoke();
        //Drop?
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void SetValues()
    {
        hp = properties.healthPoints;
        isDead = false;
    }
}

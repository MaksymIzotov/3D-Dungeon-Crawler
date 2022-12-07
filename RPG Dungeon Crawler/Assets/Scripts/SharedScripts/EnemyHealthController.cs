using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour, IDamagable
{
    public Health properties;
    public UnityEvent onDeath;

    private float maxhp;
    private float hp;
    private float defence;
    private float hpRegen;

    [HideInInspector] public bool isDead;
    private void Awake()
    {
        SetValues();
    }

    private void Update()
    {
        HealthRegen();
    }

    public void HealthRegen()
    {
        if (hp >= maxhp) { return; }

        hp += hpRegen * Time.deltaTime;
    }


    public void TakeDamage(float damage)
    {
        float actualDamage = damage - (damage / 100 * defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.ShowDamage(actualDamage, transform, transform.localScale.y);

        if (hp <= 0)
            Die();
    }


    public void Die()
    {
        if (isDead) { return; }

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
        maxhp = properties.healthPoints;
        hp = maxhp;
        defence = properties.defence;
        hpRegen = properties.healthRegen;
        isDead = false;
    }

    public void AddDefence(float _defence)
    {
        defence += _defence;
    }

    public void AddHealtRegen(float _hpRegen)
    {
        hpRegen += _hpRegen;
    }
}

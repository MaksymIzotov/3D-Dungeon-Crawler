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

    [SerializeField] private Transform damageTextParent;
    [SerializeField] private bool isExploding;

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
        if (hpRegen <= 0) { return; }

        hp += hpRegen * Time.deltaTime;
        GetComponent<EnemyHealthbar>().UpdateHealthbarValue(maxhp, hp);
    }


    public void TakeDamage(float damage, GameObject damageDealer)
    {
        float actualDamage = damage - (damage / 100 * defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.ShowDamage(actualDamage, transform, damageTextParent);
        GetComponent<EnemyHealthbar>().UpdateHealthbarValue(maxhp,hp);

        if (hp <= 0)
        {
            Die();
        }
        else
        {
            if (GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).GetComponent<PlayerPassives>().TryStun())
            {
                GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().StunState);
            }

        }
    }


    public void Die()
    {
        if (isDead) { return; }

        isDead = true;
        if (isExploding)
        {
            GetComponent<EnemyAnimationController>().StopAnimation();
            GetComponent<EnemyExplode>().Explode();
        }
        else
        {
            GetComponent<EnemyAnimationController>().Die();
        }

        onDeath.Invoke();

        Destroy(transform.Find("FX").gameObject);
        Destroy(transform.Find("EnemyHealthBar").gameObject);
        Destroy(gameObject, 5);
            
        //Drop?
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void SetValues()
    {
        maxhp = properties.healthPoints;
        maxhp *= LevelManager.Instance.enemyStatsMultiplier.healthMult;
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

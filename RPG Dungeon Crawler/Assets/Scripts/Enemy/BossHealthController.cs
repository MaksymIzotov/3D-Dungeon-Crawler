using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealthController : MonoBehaviour, IDamagable
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

    public void AddDefence(float _defence)
    {
        
    }

    public void AddHealtRegen(float _hpRegen)
    {
        
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

        BossLevelController.Instance.LevelComplpeted();

        Destroy(transform.Find("FX").gameObject);
        Destroy(gameObject, 5);
    }

    public void HealthRegen()
    {
        if (hp >= maxhp) { return; }
        if (hpRegen <= 0) { return; }

        hp += hpRegen * Time.deltaTime;
        //Update healthbar
    }

    public void TakeDamage(float damage, GameObject damageDealer)
    {
        float actualDamage = damage - (damage / 100 * defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.ShowDamage(actualDamage, transform, damageTextParent);
        //Update healthbar

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

    private void SetValues()
    {
        maxhp = properties.healthPoints;
        hp = maxhp;
        defence = properties.defence;
        hpRegen = properties.healthRegen;
        isDead = false;
    }
}

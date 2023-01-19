using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    public Health properties;

    private float maxhp;
    private float hp;
    private float lastHp;
    private float defence;
    private float hpRegen;

    private bool isDead;

    private void Awake()
    {
        SetValues();
    }

    private void Update()
    {
        HealthRegen();
    }

    private void LateUpdate()
    {
        if (lastHp != hp) { UIManager.Instance.UpdateHealth(hp); }

        lastHp = hp;
    }

    public void HealthRegen()
    {
        if (hp >= maxhp) { return; }

        hp += hpRegen * Time.deltaTime;
    }


    public void TakeDamage(float damage, GameObject damageDealer)
    {
        if (GetComponent<PlayerPassives>().TryBlockDamage())
        {
            //Add sound for blocking
            return;
        }

        float actualDamage = damage - (damage / 100 * defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.DamageEffect(actualDamage);
        GetComponent<CameraShake>().EnableShaking(actualDamage/100);

        //Try passive
        if (damageDealer != null)
            GetComponent<PlayerPassives>().ReturnDamage(damageDealer, actualDamage);


        if (hp <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        hp += amount;

        if (hp >= maxhp)
            hp = maxhp;
    }

    public void Die()
    {
        if (isDead) { return; }

        isDead = true;

        //GetComponent<LootInventory>().TransferToGlobal();
        LevelManager.Instance.onLevelLost.Invoke();
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

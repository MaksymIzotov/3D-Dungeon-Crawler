using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    public Health properties;

    private float hp;
    private float lastHp;

    private bool isDead;

    private void Start()
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
        if (hp >= properties.healthPoints) { return; }

        hp += properties.healthRegen * Time.deltaTime;
    }


    public void TakeDamage(float damage)
    {
        float actualDamage = damage - (damage / 100 * properties.defence);
        hp -= actualDamage;

        //Do effects
        DamagePopup.Instance.DamageEffect(actualDamage);

        if (hp <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        hp += amount;

        if (hp >= properties.healthPoints)
            hp = properties.healthPoints;
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
        hp = properties.healthPoints;
        isDead = false;
    }
}

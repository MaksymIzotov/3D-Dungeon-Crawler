using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    public Health properties;

    private float hp;
    private float lastHp;

    public GameObject hpTextAnim;
    public GameObject hpText;
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
        DamageEffect(actualDamage);

        if (hp <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        hp += amount;

        if (hp >= properties.healthPoints)
            hp = properties.healthPoints;
    }

    private void DamageEffect(float damage)
    {
        GameObject hpGO = Instantiate(hpTextAnim, hpText.transform);
        hpGO.GetComponent<TMP_Text>().text = damage.ToString();
    }

    public void Die()
    {
        //Player death
    }

    private void SetValues()
    {
        hp = properties.healthPoints;
    }
}

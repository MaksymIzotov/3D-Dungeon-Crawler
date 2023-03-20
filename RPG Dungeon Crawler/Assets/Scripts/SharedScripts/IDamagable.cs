using UnityEngine;

public interface IDamagable
{

    public void TakeDamage(float damage, GameObject damageDealer);
    void Die();
    void HealthRegen();
    public void AddDefence(float _defence);
    public void AddHealtRegen(float _hpRegen);
    public bool IsDead();
}

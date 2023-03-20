using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "BossAttackState", menuName = "States/Boss/Boss Attack State", order = 1)]
public class BossAttackState : EnemyBaseState
{
    [Header("Shoot skull properties")]
    public GameObject skullPrefab;
    public float delay;
    public int attacksAmount;
    public float damage;

    private int attackType;
    private bool isAttacking;


    public override void EnterState(EnemyStateManager manager)
    {
        isAttacking = false;

        //Choose attack type
        attackType = Random.Range(0, 1);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        
        if (!isAttacking) {
            switch (attackType)
            {
                case 0:                   
                    ShootSkulllAttack(manager);
                    break;
            }
        }
    }

    private void ShootSkulllAttack(EnemyStateManager manager)
    {
        isAttacking = true;
        manager.GetComponent<EnemyAnimationController>().BossShoot();
        manager.StartCoroutine(ShootSkull(manager));
    }

    IEnumerator ShootSkull(EnemyStateManager manager)
    {
        int i = 0;
        do
        {
            GameObject projectile = Instantiate(skullPrefab, manager.eyes.position, manager.transform.rotation);
            projectile.GetComponent<FollowProjectileController>().SetDamage(damage, manager.gameObject);

            i++;
            yield return new WaitForSeconds(delay);
        } while (i < attacksAmount);

        manager.SwitchState(manager.ChasingState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public EnemyAttack properties;

    public bool isAttacking = false;
    [SerializeField] private Transform projectileSpawnpoint;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform attackPointAbove;

    public void Attack()
    {
        StartCoroutine(PreAttack());
    }

    public void Push()
    {
        StartCoroutine(PrePush());
    }

    public void AttackAbove()
    {
        StartCoroutine(PreAttackAbove());
    }

    IEnumerator PreAttack()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().Attack();

        yield return new WaitForSeconds(properties.preAttackTimeShooting);

        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        //Shoot projectile
        GameObject bullet = Instantiate(properties.bullet, projectileSpawnpoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDamage(properties.damage, gameObject);

        yield return new WaitForSeconds(properties.attackDelayShooting);

        isAttacking = false;
    }

    IEnumerator PrePush()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().PushAway();

        yield return new WaitForSeconds(properties.preAttackTimeMelee);

        StartCoroutine(PerformPush());
    }

    IEnumerator PerformPush()
    {
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        //Deal damage
        if (attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {

            player.GetComponent<PlayerHealthController>().TakeDamage(properties.damage, gameObject);
            player.GetComponent<PlayerController>().AddImpact(transform, 100);
        }

        yield return new WaitForSeconds(properties.attackDelayMelee);

        isAttacking = false;
    }

    IEnumerator PreAttackAbove()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().AttackAbove();

        yield return new WaitForSeconds(properties.preAttackTimeMelee);

        StartCoroutine(PerformAttackAbove());
    }

    IEnumerator PerformAttackAbove()
    {
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        //Deal damage
        if (attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            player.GetComponent<PlayerHealthController>().TakeDamage(properties.damage, gameObject);
            player.GetComponent<PlayerController>().AddImpact(transform, 300);
        }

        yield return new WaitForSeconds(properties.attackDelayMelee);

        isAttacking = false;
    }
}

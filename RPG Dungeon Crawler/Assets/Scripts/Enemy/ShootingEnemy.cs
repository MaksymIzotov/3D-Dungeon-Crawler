using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public EnemyAttack properties;

    public bool isAttacking = false;
    public Transform attackPoint;

    public void Attack()
    {
        StartCoroutine(PreAttack());
    }

    IEnumerator PreAttack()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().Attack();

        yield return new WaitForSeconds(properties.preAttackTime);

        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        //Shoot projectile || TODO: Player position prediction
        GameObject bullet = Instantiate(properties.bullet, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDamage(properties.damage, gameObject);

        yield return new WaitForSeconds(properties.attackDelay);

        isAttacking = false;
    }
}

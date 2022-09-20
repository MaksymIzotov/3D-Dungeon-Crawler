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
        Instantiate(properties.bullet, attackPoint.position, attackPoint.rotation);

        yield return new WaitForSeconds(properties.attackDelay);

        isAttacking = false;
    }
}

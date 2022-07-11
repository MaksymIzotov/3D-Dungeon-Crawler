using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAttackController : MonoBehaviour
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
        //Deal damage
        Collider[] objectsNearby = Physics.OverlapSphere(attackPoint.position, 0.7f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<PlayerHealthController>().TakeDamage(properties.damage);
            }
        }

        yield return new WaitForSeconds(properties.attackDelay);

        isAttacking = false;
    }
}

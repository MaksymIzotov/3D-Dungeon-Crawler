using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAttackController : MonoBehaviour
{
    public EnemyAttack properties;

    public bool isAttacking = false;

    public void Attack()
    {
        StartCoroutine(PreAttack());
    }

    IEnumerator PreAttack()
    {
        isAttacking = true;

        EnemyAnimationController.Instance.Attack();

        yield return new WaitForSeconds(properties.preAttackTime);

        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        //Deal damage
        Collider[] objectsNearby = Physics.OverlapSphere(transform.position, 2f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAttackController : MonoBehaviour
{
    public EnemyAttack properties;

    public bool isAttacking = false;
    public Transform attackPoint;
    [SerializeField] private Transform eyes;
    [SerializeField] private bool isAddingImpact;

    public void Attack()
    {
        StartCoroutine(PreAttack());
    }

    public void AttackAbove()
    {
        StartCoroutine(PreAttackAbove());
    }

    IEnumerator PreAttackAbove()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().AttackAbove();

        yield return new WaitForSeconds(properties.preAttackTime);

        StartCoroutine(PerformAttackAbove());
    }

    IEnumerator PerformAttackAbove()
    {
        //Deal damage
        Collider[] objectsNearby = Physics.OverlapSphere(eyes.position, 2f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<PlayerHealthController>().TakeDamage(properties.damage, gameObject);

                if (isAddingImpact)
                    col.GetComponent<PlayerController>().AddImpact(transform, 200);
            }
        }

        yield return new WaitForSeconds(properties.attackDelay);

        isAttacking = false;
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
        Collider[] objectsNearby = Physics.OverlapSphere(attackPoint.position, 3f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<PlayerHealthController>().TakeDamage(properties.damage, gameObject);
                col.GetComponent<PlayerController>().AddImpact(transform, 100);
            }
        }

        yield return new WaitForSeconds(properties.attackDelay);

        isAttacking = false;
    }
}

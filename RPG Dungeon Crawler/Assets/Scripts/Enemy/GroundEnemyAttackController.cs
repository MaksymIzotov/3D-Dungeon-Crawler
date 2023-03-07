using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAttackController : MonoBehaviour
{
    public EnemyAttack properties;

    public bool isAttacking = false;
    public GameObject attackPoint;
    public GameObject attackPointAbove;
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

        yield return new WaitForSeconds(properties.preAttackTimeMelee);

        StartCoroutine(PerformAttackAbove());
    }

    IEnumerator PerformAttackAbove()
    {
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        GetComponent<EnemyAudio>().PlayAttackAbove();

        //Deal damage
        if (attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            player.GetComponent<PlayerHealthController>().TakeDamage(properties.damage * LevelManager.Instance.enemyStatsMultiplier.damageMult, gameObject);
            player.GetComponent<PlayerController>().AddImpact(transform, 300);
        }

        yield return new WaitForSeconds(properties.attackDelayMelee);

        isAttacking = false;
    }

    IEnumerator PreAttack()
    {
        isAttacking = true;

        GetComponent<EnemyAnimationController>().Attack();

        yield return new WaitForSeconds(properties.preAttackTimeMelee);

        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        //Deal damage
        if (attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            GetComponent<EnemyAudio>().PlayAttack();

            player.GetComponent<PlayerHealthController>().TakeDamage(properties.damage * LevelManager.Instance.enemyStatsMultiplier.damageMult, gameObject);

            if (isAddingImpact)
                player.GetComponent<PlayerController>().AddImpact(transform, 100);

        }
        else
        {
            GetComponent<EnemyAudio>().PlayAttackMissed();
        }

        yield return new WaitForSeconds(properties.attackDelayMelee);

        isAttacking = false;
    }
}

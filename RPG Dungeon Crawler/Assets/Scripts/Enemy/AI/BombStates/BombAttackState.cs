using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombAttackState", menuName = "States/Bomb/Bomb Attack State", order = 2)]
public class BombAttackState : EnemyBaseState
{
    public EnemyAttack properties;
    public GameObject explodePrefab;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponent<GroundEnemyMovementController>().StopAgent();
        //Explode
        //Play sound

        manager.GetComponent<EnemyAnimationController>().Attack();
        manager.StartCoroutine(Delay(manager));
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        
    }

    IEnumerator Delay(EnemyStateManager manager)
    {
        yield return new WaitForSeconds(properties.preAttackTimeMelee);
        Explode(manager);
    }

    private void Explode(EnemyStateManager manager)
    {
        Collider[] colliders = Physics.OverlapSphere(manager.transform.position, 5);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag(TAGS.PLAYER_TAG))
            {
                col.gameObject.GetComponent<IDamagable>()?.TakeDamage(properties.damage, null);
            }
        }

        Instantiate(explodePrefab, manager.transform.position, Quaternion.identity);
        manager.GetComponent<EnemyExplode>().Explode();
        manager.GetComponent<EnemyHealthController>().Die();

        Destroy(manager.gameObject, 2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeAttackState", menuName = "States/Spooky Eye/Eye Attack State", order = 3)]
public class EyeAttackState : EnemyBaseState
{
    public float shootingRange = 1f;

    GameObject player;

    private int layerMask;
    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layerMask = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.gameObject.GetComponent<ShootingEnemy>().isAttacking) { return; }

        if (player.GetComponent<PlayerPassives>().isInvisible)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.IdleState);
            return;
        }

        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.gameObject.GetComponent<ShootingEnemy>().Push();
            return;
        }

        if (manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.gameObject.GetComponent<ShootingEnemy>().AttackAbove();
            return;
        }

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, shootingRange, ~layerMask))
        {
            if (hit.transform.tag == "Player")
            {
                manager.gameObject.GetComponent<ShootingEnemy>().Attack();
                return;
            }
        }

        manager.SwitchState(manager.ChasingState);
    }
}

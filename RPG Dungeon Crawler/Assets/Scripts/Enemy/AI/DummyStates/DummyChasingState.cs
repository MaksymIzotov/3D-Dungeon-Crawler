using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyChasingState", menuName = "States/Dummy/Dummy Chasing State", order = 3)]
public class DummyChasingState : EnemyBaseState
{
    GameObject player;

    LayerMask ignore;
    public override void EnterState(EnemyStateManager manager)
    {
        manager.gameObject.GetComponent<EnemyAnimationController>().Chase();

        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        manager.GetComponent<GroundEnemyMovementController>().ChangeDestination();

        //If player is in attack range check
        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange() ||
            manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.AttackingState);
        }
    }
}

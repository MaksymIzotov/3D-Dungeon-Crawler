using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyChasingState", menuName = "States/Dummy/Dummy Chasing State", order = 3)]
public class DummyChasingState : EnemyBaseState
{
    GameObject player;

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        manager.gameObject.GetComponent<EnemyAnimationController>().Chase();
        manager.GetComponent<EnemyAudio>().Walk();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (player.GetComponent<PlayerPassives>().isInvisible)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.IdleState);
            return;
        }

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

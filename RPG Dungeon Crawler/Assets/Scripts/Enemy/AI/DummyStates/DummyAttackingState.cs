using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DummyAttackState", menuName = "States/Dummy/Dummy Attacking State", order = 2)]
public class DummyAttackingState : EnemyBaseState
{
    GameObject player;

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
        manager.GetComponent<EnemyAudio>().Stop();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.gameObject.GetComponent<GroundEnemyAttackController>().isAttacking) { return; }
        if (player.GetComponent<PlayerPassives>().isInvisible)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.IdleState);
            return;
        }


        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.gameObject.GetComponent<GroundEnemyAttackController>().Attack();
            return;
        }

        if (manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.gameObject.GetComponent<GroundEnemyAttackController>().AttackAbove();
            return;
        }

        manager.SwitchState(manager.ChasingState);
    }
}

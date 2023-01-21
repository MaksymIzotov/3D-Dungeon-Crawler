using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DummyAttackState", menuName = "States/Dummy/Dummy Attacking State", order = 2)]
public class DummyAttackingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
       
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.gameObject.GetComponent<GroundEnemyAttackController>().isAttacking) { return; }

        bool isPlayerInRange = false;

        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            isPlayerInRange = true;
            manager.gameObject.GetComponent<GroundEnemyAttackController>().Attack();
        }

        if (manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            isPlayerInRange = true;
            manager.gameObject.GetComponent<GroundEnemyAttackController>().AttackAbove();
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }
    }
}

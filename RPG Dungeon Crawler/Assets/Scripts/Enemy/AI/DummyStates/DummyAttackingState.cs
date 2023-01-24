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

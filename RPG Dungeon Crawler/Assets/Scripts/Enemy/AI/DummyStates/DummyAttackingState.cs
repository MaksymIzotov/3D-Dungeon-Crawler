using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttackingState : EnemyBaseState
{
    Transform startPos;

    GroundEnemyAttackController attackController;
    public override void EnterState(EnemyStateManager manager)
    {
        startPos = manager.transform;
        attackController = manager.gameObject.GetComponent<GroundEnemyAttackController>();
    }

    public override void UpdateState(EnemyStateManager manager)
    {

        if (attackController.isAttacking) { return; }

        bool isPlayerInRange = false;

        Collider[] objectsNearby = Physics.OverlapSphere(startPos.position, 2f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == "Player")
            {
                isPlayerInRange = true;
                break;
            }
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        attackController.Attack();
    }
}

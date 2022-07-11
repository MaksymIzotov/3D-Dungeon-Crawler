using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttackingState : EnemyBaseState
{
    Transform startPos;
    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation

        startPos = manager.transform;
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        //Attack

        Collider[] objectsNearby = Physics.OverlapSphere(startPos.position, 5f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == "Player")
                return;
        }

        manager.SwitchState(manager.ChasingState);
    }
}

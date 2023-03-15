using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "StunState", menuName = "States/Shared/StunState", order = 1)]
public class StunState : EnemyBaseState
{
    float stunDuration = 2f;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.gameObject.GetComponent<EnemyAnimationController>().Idle();
        manager.gameObject.GetComponent<EnemyStatesHelper>().Stun(stunDuration);
        manager.GetComponent<GroundEnemyMovementController>().StopAgent();

        //Add FX
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        
    }
}

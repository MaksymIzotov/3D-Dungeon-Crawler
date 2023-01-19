using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundStomp", menuName = "States/Shared/GroundStomp", order = 1)]
public class GroundStompState : EnemyBaseState
{

    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponent<EnemyAnimationController>().GroundStomp();

        //Add FX
    }

    public override void UpdateState(EnemyStateManager manager)
    {

    }
}

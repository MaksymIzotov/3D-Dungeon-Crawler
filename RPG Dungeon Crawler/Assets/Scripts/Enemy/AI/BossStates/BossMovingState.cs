using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovingState : EnemyBaseState
{
    [Header("Settings")]

    public float minWalkingTime;
    public float maxWalkingTime;

    private float walkingTime;

    private Transform walkingPoint;

    public override void EnterState(EnemyStateManager manager)
    {
        walkingTime = Random.Range(minWalkingTime, maxWalkingTime);
        walkingPoint = PickNextWaypoint();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        walkingTime -= Time.deltaTime;

        if(walkingTime <= 0)
        {
            //Change state
        }
    }

    private Transform PickNextWaypoint()
    {
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnState", menuName = "States/Shared/Spawn State", order = 1)]
public class SpawnState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        manager.transform.localScale = Vector3.Lerp(manager.transform.localScale, Vector3.one, 2*Time.deltaTime);

        if(Vector3.Distance(manager.transform.localScale, Vector3.one) < 0.1f)
        {
            manager.transform.localScale = Vector3.one;
            manager.SwitchState(manager.IdleState);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyIdleState", menuName = "States/Dummy/Dummy Idle State", order = 1)]
public class DummyIdleState : EnemyBaseState
{
    GameObject player;
    LayerMask ignore;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponent<EnemyAnimationController>().Idle();
        manager.GetComponent<GroundEnemyMovementController>().StopAtPosition();

        player = GameObject.FindGameObjectWithTag("Player");

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag == "Player")
                manager.SwitchState(manager.ChasingState);
        }
    }
}

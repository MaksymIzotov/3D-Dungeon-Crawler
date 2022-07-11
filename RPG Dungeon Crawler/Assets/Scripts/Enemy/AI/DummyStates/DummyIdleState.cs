using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyIdleState : EnemyBaseState
{
    GameObject player;
    Transform startPos;
    LayerMask ignore;

    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation

        player = GameObject.FindGameObjectWithTag("Player");
        startPos = manager.transform;

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - startPos.position;
        if (Physics.Raycast(startPos.position, rayDirection, out hit, 1000f,~ignore))
        {
            if (hit.transform.tag == "Player")
                manager.SwitchState(manager.ChasingState);
        }
    }
}

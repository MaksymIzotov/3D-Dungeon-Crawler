using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeIdleState", menuName = "States/Spooky Eye/Eye Idle State", order = 1)]
public class EyeIdleState : EnemyBaseState
{
    GameObject player;
    Transform startPos;
    LayerMask ignore;

    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Idle();

        player = GameObject.FindGameObjectWithTag("Player");
        startPos = manager.transform;

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - startPos.position;
        if (Physics.Raycast(startPos.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag == "Player")
                manager.SwitchState(manager.ChasingState);
        }
    }
}

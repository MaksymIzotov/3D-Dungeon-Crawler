using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeIdleState", menuName = "States/Spooky Eye/Eye Idle State", order = 1)]
public class EyeIdleState : EnemyBaseState
{
    GameObject player;
    LayerMask ignore;

    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Idle();

        player = GameObject.FindGameObjectWithTag("Player");

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (player.GetComponent<PlayerPassives>().isInvisible)
        {  
            return;
        }

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag == "Player")
                manager.SwitchState(manager.ChasingState);
        }
    }
}

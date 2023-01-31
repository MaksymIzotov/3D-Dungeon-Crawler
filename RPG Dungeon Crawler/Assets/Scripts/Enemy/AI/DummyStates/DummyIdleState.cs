using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyIdleState", menuName = "States/Dummy/Dummy Idle State", order = 1)]
public class DummyIdleState : EnemyBaseState
{
    GameObject player;
    public LayerMask ignore;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.gameObject.GetComponent<EnemyAnimationController>().Idle();
        manager.GetComponent<EnemyAudio>().Stop();

        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag == TAGS.PLAYER_TAG)
                manager.SwitchState(manager.ChasingState);
        }
    }
}

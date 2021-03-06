using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyChasingState", menuName = "States/Dummy/Dummy Chasing State", order = 3)]
public class DummyChasingState : EnemyBaseState
{
    GroundEnemyMovementController controller;

    GameObject player;
    Transform startPos;

    LayerMask ignore;
    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Chase();
        controller = manager.gameObject.GetComponent<GroundEnemyMovementController>();

        player = GameObject.FindGameObjectWithTag("Player");
        startPos = manager.transform;

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        controller.ChasePlayer();

        //If player is out of sight check
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - startPos.position;
        if (Physics.Raycast(startPos.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag != "Player")
                manager.SwitchState(manager.IdleState);
        }

        //If player is in attack range check
        RaycastHit attackHit;
        if (Physics.Raycast(startPos.position, startPos.TransformDirection(Vector3.forward), out attackHit, 2f))
        {
            if (attackHit.transform.tag == "Player")
            {
                controller.StopAtPosition();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

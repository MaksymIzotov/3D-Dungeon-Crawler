using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyChasingState", menuName = "States/Dummy/Dummy Chasing State", order = 3)]
public class DummyChasingState : EnemyBaseState
{
    GameObject player;

    LayerMask ignore;
    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Chase();

        player = GameObject.FindGameObjectWithTag("Player");

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        manager.GetComponent<GroundEnemyMovementController>().ChasePlayer();

        //If player is out of sight check
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.eyes.transform.position;
        if (Physics.Raycast(manager.eyes.transform.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag != "Player")
                manager.SwitchState(manager.IdleState);
        }

        //If player is in attack range check
        RaycastHit attackHit;
        if (Physics.Raycast(manager.transform.position, manager.transform.TransformDirection(Vector3.forward), out attackHit, 2f))
        {
            if (attackHit.transform.tag == "Player")
            {
                manager.GetComponent<GroundEnemyMovementController>().StopAtPosition();
                manager.SwitchState(manager.AttackingState);
            }
        }

        RaycastHit hitAbove;
        if (Physics.Raycast(manager.eyes.transform.position, manager.eyes.transform.TransformDirection(Vector3.up), out hitAbove, 1f))
        {
            if (hitAbove.transform.tag == "Player")
            {
                manager.GetComponent<GroundEnemyMovementController>().StopAtPosition();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

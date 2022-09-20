using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeChasingState", menuName = "States/Spooky Eye/Eye Chasing State", order = 2)]
public class EyeChasingState : EnemyBaseState
{
    public float shootingRange = 1f;

    FlyingEnemyMovement controller;

    GameObject player;
    Transform startPos;

    LayerMask ignore;
    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Chase();
        controller = manager.gameObject.GetComponent<FlyingEnemyMovement>();

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
        if (Physics.Raycast(startPos.position, rayDirection, out attackHit, shootingRange))
        {
            if (attackHit.transform.tag == "Player")
            {
                controller.StopAtPosition();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

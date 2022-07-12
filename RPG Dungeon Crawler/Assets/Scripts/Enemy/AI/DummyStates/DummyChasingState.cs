using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChasingState : EnemyBaseState
{
    GroundEnemyMovementController controller;

    GameObject player;
    Transform startPos;
    Transform attackPos;

    LayerMask ignore;
    public override void EnterState(EnemyStateManager manager)
    {
        //Start animation
        manager.GetComponent<EnemyAnimationController>().Chase();
        controller = manager.gameObject.GetComponent<GroundEnemyMovementController>();

        player = GameObject.FindGameObjectWithTag("Player");
        startPos = manager.transform;
        attackPos = manager.attackPoint;

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
        Collider[] objectsNearby = Physics.OverlapSphere(attackPos.position, 1f);
        foreach(Collider col in objectsNearby)  
        {
            if (col.tag == "Player")
            {
                controller.StopAtPosition();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

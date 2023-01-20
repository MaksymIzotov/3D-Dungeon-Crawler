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
        manager.gameObject.GetComponent<EnemyAnimationController>().Chase();

        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        ignore = LayerMask.GetMask("Enemy");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        manager.GetComponent<GroundEnemyMovementController>().ChangeDestination();

        //If player is in attack range check
        RaycastHit attackHit;
        if (Physics.Raycast(manager.transform.position, manager.transform.TransformDirection(Vector3.forward), out attackHit, 2f))
        {
            if (attackHit.transform.tag == TAGS.PLAYER_TAG)
            {
                manager.GetComponent<GroundEnemyMovementController>().StopAgent();
                manager.SwitchState(manager.AttackingState);
            }
        }

        Collider[] objectsNearby = Physics.OverlapSphere(manager.eyes.position, 2f);
        foreach (Collider col in objectsNearby)
        {
            if (col.tag == TAGS.PLAYER_TAG)
            {
                manager.GetComponent<GroundEnemyMovementController>().StopAgent();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GolemChasingState", menuName = "States/Golem/Golem Chasing State", order = 1)]
public class GolemChasingState : EnemyBaseState
{
    public float stompChance;

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
        if (Physics.Raycast(manager.attackPoint.position, manager.attackPoint.TransformDirection(Vector3.forward), out attackHit, 2f))
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

        float rand = Random.Range(0f,100f);
        if(rand <= stompChance)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.GroundStompState);
        }
    }
}

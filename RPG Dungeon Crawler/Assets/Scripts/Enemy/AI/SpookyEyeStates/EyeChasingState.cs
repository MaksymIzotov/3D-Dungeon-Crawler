using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeChasingState", menuName = "States/Spooky Eye/Eye Chasing State", order = 2)]
public class EyeChasingState : EnemyBaseState
{
    public float shootingRange = 1f;

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
        if (player.GetComponent<PlayerPassives>().isInvisible)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.IdleState);
            return;
        }

        manager.gameObject.GetComponent<GroundEnemyMovementController>().ChangeDestination();

        //If player is out of sight check
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, 1000f, ~ignore))
        {
            if (hit.transform.tag != "Player")
                manager.SwitchState(manager.IdleState);
        }

        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange() ||
           manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.GetComponent<GroundEnemyMovementController>().StopRanged();
            manager.SwitchState(manager.AttackingState);
        }

        //If player is in attack range check
        RaycastHit attackHit;
        if (Physics.Raycast(manager.transform.position, rayDirection, out attackHit, shootingRange, ~ignore))
        {
            if (attackHit.transform.tag == "Player")
            {
                manager.gameObject.GetComponent<GroundEnemyMovementController>().StopRanged();
                manager.SwitchState(manager.AttackingState);
            }
        }
    }
}

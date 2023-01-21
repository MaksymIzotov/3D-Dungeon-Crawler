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

        if (manager.attackPoint.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange() ||
            manager.attackPointAbove.GetComponent<EnemyAttackCheck>().GetIsPlayerInRange())
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.AttackingState);
        }

        float rand = Random.Range(0f,100f);
        if(rand <= stompChance)
        {
            manager.GetComponent<GroundEnemyMovementController>().StopAgent();
            manager.SwitchState(manager.GroundStompState);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DummyAttackState", menuName = "States/Dummy/Dummy Attacking State", order = 2)]
public class DummyAttackingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
       
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.gameObject.GetComponent<GroundEnemyAttackController>().isAttacking) { return; }

        bool isPlayerInRange = false;

        RaycastHit hitAttack;
        if (Physics.Raycast(manager.transform.position, manager.transform.TransformDirection(Vector3.forward), out hitAttack, 2f))
        {
            if (hitAttack.transform.tag == "Player")
            {
                isPlayerInRange = true;
                manager.gameObject.GetComponent<GroundEnemyAttackController>().Attack();
            }
        }

        RaycastHit hitAbove;
        if (Physics.Raycast(manager.eyes.transform.position, manager.eyes.transform.TransformDirection(Vector3.up), out hitAbove, 1f))
        {
            if (hitAbove.transform.tag == "Player")
            {
                isPlayerInRange = true;
                manager.gameObject.GetComponent<GroundEnemyAttackController>().AttackAbove();
            }
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        
    }
}

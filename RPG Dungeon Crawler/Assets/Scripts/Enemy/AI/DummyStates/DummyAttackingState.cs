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

        RaycastHit hit;
        if (Physics.Raycast(manager.transform.position, manager.transform.TransformDirection(Vector3.forward), out hit, 2f))
        {
            if (hit.transform.tag == "Player")
                isPlayerInRange = true;
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        manager.gameObject.GetComponent<GroundEnemyAttackController>().Attack();
    }
}

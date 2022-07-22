using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DummyAttackState", menuName = "States/Dummy/Dummy Attacking State", order = 2)]
public class DummyAttackingState : EnemyBaseState
{
    Transform startPos;

    GroundEnemyAttackController attackController;
    public override void EnterState(EnemyStateManager manager)
    {
        startPos = manager.transform;
        attackController = manager.gameObject.GetComponent<GroundEnemyAttackController>();
    }

    public override void UpdateState(EnemyStateManager manager)
    {

        if (attackController.isAttacking) { return; }

        bool isPlayerInRange = false;

        RaycastHit hit;
        if (Physics.Raycast(startPos.position, startPos.TransformDirection(Vector3.forward), out hit, 2f))
        {
            if (hit.transform.tag == "Player")
                isPlayerInRange = true;
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        attackController.Attack();
    }
}

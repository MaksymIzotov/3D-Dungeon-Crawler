using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeAttackState", menuName = "States/Spooky Eye/Eye Attack State", order = 3)]
public class EyeAttackState : EnemyBaseState
{
    public float shootingRange = 1f;

    Transform startPos;
    GameObject player;

    ShootingEnemy attackController;
    public override void EnterState(EnemyStateManager manager)
    {
        startPos = manager.transform;
        attackController = manager.gameObject.GetComponent<ShootingEnemy>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (attackController.isAttacking) { return; }

        bool isPlayerInRange = false;

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - startPos.position;
        if (Physics.Raycast(startPos.position, rayDirection, out hit, shootingRange))
        {
            if (hit.transform.tag == "Player")
                isPlayerInRange = true;
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        attackController.Attack();
    }
}

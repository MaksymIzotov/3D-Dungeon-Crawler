using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EyeAttackState", menuName = "States/Spooky Eye/Eye Attack State", order = 3)]
public class EyeAttackState : EnemyBaseState
{
    public float shootingRange = 1f;

    GameObject player;
    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.gameObject.GetComponent<ShootingEnemy>().isAttacking) { return; }

        bool isPlayerInRange = false;

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - manager.transform.position;
        if (Physics.Raycast(manager.transform.position, rayDirection, out hit, shootingRange))
        {
            if (hit.transform.tag == "Player")
                isPlayerInRange = true;
        }

        if (!isPlayerInRange) { manager.SwitchState(manager.ChasingState); return; }

        manager.gameObject.GetComponent<ShootingEnemy>().Attack();
    }
}

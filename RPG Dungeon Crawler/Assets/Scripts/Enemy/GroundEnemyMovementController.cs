using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyMovementController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;

    private EnemyAnimationController ac;

    public float rotationSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ac = GetComponent<EnemyAnimationController>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.angularSpeed = 0;
        agent.isStopped = true;
    }

    private void Update()
    {
        if (GetComponent<EnemyStateManager>().GetCurrentState() == GetComponent<EnemyStateManager>().GroundStompState) { RotateEnemy(); }

        if (agent.isStopped) { return; }

        RotateEnemy();
    }

    private void RotateEnemy()
    {
        Quaternion lookRotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
    }

    public void ChasePlayer()
    {
        ac.Chase();

        agent.isStopped = false;
    }

    public void ChangeDestination()
    {
        agent.SetDestination(player.transform.position);
    }

    public void StopAgent()
    {
        agent.isStopped = true;
    }
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyMovementController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;

    public float rotationSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.angularSpeed = 0;
        agent.isStopped = true;
    }

    private void Update()
    {
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
        agent.isStopped = false;
        agent.destination = player.transform.position;
    } 

    public void StopAtPosition()
    {
        agent.isStopped = true;
    }
}

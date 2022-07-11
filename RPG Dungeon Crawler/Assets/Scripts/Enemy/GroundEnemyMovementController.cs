using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyMovementController : MonoBehaviour
{
    public float speed;

    private NavMeshAgent agent;
    private GameObject player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");     
    }

    private void Update()
    {
        //ChasePlayer();
    }

    public void ChasePlayer()
    {
        agent.destination = player.transform.position;
    } 

    public void StopAtPosition(Transform pos)
    {
        agent.destination = pos.position;
    }
}

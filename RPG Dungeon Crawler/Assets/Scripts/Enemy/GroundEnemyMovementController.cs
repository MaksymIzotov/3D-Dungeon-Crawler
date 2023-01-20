using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class GroundEnemyMovementController : MonoBehaviour
{
    private GameObject player;
    private EnemyAnimationController ac;
    private AIPath aiPath;

    private void Start()
    {
        ac = GetComponent<EnemyAnimationController>();
        player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
    }

    public void ChasePlayer()
    {
        ac.Chase();
    }

    public void ChangeDestination()
    {
        aiPath.destination = player.transform.position;
    }

    public void StopAgent()
    {
        aiPath.destination = transform.position;
    }  
}

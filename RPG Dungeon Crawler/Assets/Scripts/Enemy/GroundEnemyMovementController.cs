using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class GroundEnemyMovementController : MonoBehaviour
{
    private GameObject player;
    private AIPath aiPath;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
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

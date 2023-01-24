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

    private void Update()
    {
        if (aiPath.enableRotation) { return; }

        RotateEnemy();
    }

    public void ChangeDestination()
    {
        aiPath.destination = player.transform.position;
    }

    public void StopAgent()
    {
        aiPath.destination = transform.position;
    }

    private void RotateEnemy()
    {
        Quaternion lookRotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
    }
}

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

    private void RotateEnemy()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
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

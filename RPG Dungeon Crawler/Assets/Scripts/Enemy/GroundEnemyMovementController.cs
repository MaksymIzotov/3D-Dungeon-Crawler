using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class GroundEnemyMovementController : MonoBehaviour
{
    private GameObject player;
    private AIPath aiPath;

    private bool isStopped = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
        aiPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        if (aiPath.enableRotation) { return; }
        if (isStopped) { return; }

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
        isStopped = false;
        aiPath.destination = player.transform.position;
        aiPath.isStopped = false;
    }

    public void StopAgent()
    {
        isStopped = true;
        aiPath.destination = transform.position;
    }

    public void StopRanged()
    {
        aiPath.isStopped = true;
    }
}

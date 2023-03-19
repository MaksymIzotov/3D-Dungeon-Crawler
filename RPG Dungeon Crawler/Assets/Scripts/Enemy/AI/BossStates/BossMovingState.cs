using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "BossMovingState", menuName = "States/Boss/Boss Moving State", order = 1)]
public class BossMovingState : EnemyBaseState
{
    [Header("Settings")]

    public float minWalkingTime;
    public float maxWalkingTime;

    private float walkingTime;

    private Vector3 walkingPoint;
    private GameObject player;

    private Quaternion lookRotation;

    public override void EnterState(EnemyStateManager manager)
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        walkingTime = Random.Range(minWalkingTime, maxWalkingTime);
        walkingPoint = PickNextWaypoint(manager.transform.position.y);

        manager.GetComponent<AIPath>().destination = walkingPoint;
        manager.GetComponent<EnemyAnimationController>().Chase();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        lookRotation = Quaternion.LookRotation((player.transform.position - manager.transform.position).normalized);
        manager.transform.rotation = Quaternion.Slerp(manager.transform.rotation, new Quaternion(manager.transform.rotation.x, lookRotation.y, manager.transform.rotation.z, manager.transform.rotation.w), 10f * Time.deltaTime);

        walkingTime -= Time.deltaTime;

        if (Vector3.Distance(manager.transform.position, walkingPoint) < 0.5f)
        {
            walkingPoint = PickNextWaypoint(manager.transform.position.y);
            manager.GetComponent<AIPath>().destination = walkingPoint;
        }

        if (walkingTime <= 0)
        {
            int rand = Random.Range(0, 100);
            if (rand < 25)
                manager.SwitchState(manager.SpawnEnemiesState);
            else
                manager.SwitchState(manager.SpawnEnemiesState);

            manager.GetComponent<AIPath>().destination = manager.transform.position;
        }
    }

    private Vector3 PickNextWaypoint(float yValue)
    {
        GameObject[] borders = GameObject.FindGameObjectsWithTag(TAGS.BORDER_TAG);

        float[] xValues = new float[borders.Length];
        for (int i = 0; i < borders.Length; i++)
        {
            xValues[i] = borders[i].transform.position.x;
        }

        float[] zValues = new float[borders.Length];
        for (int i = 0; i < borders.Length; i++)
        {
            zValues[i] = borders[i].transform.position.z;
        }

        return new Vector3(
            Random.Range(ExtensionMethods.GetMin(xValues), ExtensionMethods.GetMax(xValues)), // Find x pos
            yValue,                                                                           // Return static y pos
            Random.Range(ExtensionMethods.GetMin(zValues), ExtensionMethods.GetMax(zValues))  // Find z pos
            );
    }
}

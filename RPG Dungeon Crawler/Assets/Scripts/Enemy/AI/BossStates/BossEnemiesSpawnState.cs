using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossEnemiesSpawnState", menuName = "States/Boss/Boss Enemies Spawn State", order = 1)]
public class BossEnemiesSpawnState : EnemyBaseState
{
    [Header("Settings")]

    public float minDelay;
    public float maxDelay;
    public int minAmount;
    public int maxAmount;

    [Space(10)]
    [Header("Enemies")]

    public GameObject[] enemiesPrefab;
    private GameObject[] spawnPoints;

    private bool isFinished;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponent<EnemyAnimationController>().BossEnemySpawn();
        isFinished = false;

        spawnPoints = GameObject.FindGameObjectsWithTag(TAGS.SPAWNER_TAG);
        int amount = Random.Range(minAmount, maxAmount);

        manager.StartCoroutine(SpawnEnemy(amount));
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (isFinished)
            manager.SwitchState(manager.ChasingState);
    }

    IEnumerator SpawnEnemy(int amount)
    {
        int i = 0;
        do
        {
            Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            i++;
        }
        while (i < amount);

        isFinished = true;
    }
}

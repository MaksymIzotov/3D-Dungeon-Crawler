using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesSpawnSettings", menuName = "Settings/EnemySpawnSettings", order = 1)]
public class EnemiesSpawnSettings : ScriptableObject
{
    public int enemiesAmount;
    public float minDelay, maxDelay;

    public GameObject[] enemies;
}

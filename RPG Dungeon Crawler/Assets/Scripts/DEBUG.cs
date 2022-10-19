using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public void SpawnEnemyAtFirstRoom()
    {
        GameObject player = Instantiate(enemyPrefab, PlayerSpawner.Instance.GetSpawnPoint().transform.position, Quaternion.identity);
    }

    private void Update()
    {
        
    }
}

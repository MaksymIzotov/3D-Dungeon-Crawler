using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        Invoke("SpawnEnemyAtFirstRoom", 5);
    }

    public void SpawnEnemyAtFirstRoom()
    {
        GameObject player = Instantiate(enemyPrefab, PlayerSpawner.Instance.GetSpawnPoint().transform.position, Quaternion.identity);
    }

    private void Update()
    {
        
    }
}

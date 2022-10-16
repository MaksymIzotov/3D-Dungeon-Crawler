using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region Singleton Init

    public static PlayerSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private GameObject playerPrefab;

    public void SpawnPlayer()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");

        int index = 0;
        float minDist = Vector3.Distance(Vector3.zero, spawnPoints[0].transform.position);
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            float dist = Vector3.Distance(Vector3.zero, spawnPoints[i].transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                index = i;
            }
        }

        GameObject player = Instantiate(playerPrefab, spawnPoints[index].transform.position, Quaternion.identity);
        //Do something to player before start
    }
}

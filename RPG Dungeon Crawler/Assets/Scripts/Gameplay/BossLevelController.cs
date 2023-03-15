using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();
    }
}

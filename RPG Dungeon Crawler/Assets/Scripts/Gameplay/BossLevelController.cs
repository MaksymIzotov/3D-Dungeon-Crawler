using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelController : MonoBehaviour
{
    public static BossLevelController Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();
    }

    public void LevelComplpeted()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class NavMeshBaking : MonoBehaviour
{
    #region Singleton Init

    public static NavMeshBaking Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void BakeNavMesh()
    {
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }
}

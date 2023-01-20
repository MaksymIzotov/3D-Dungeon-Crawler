using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaking : MonoBehaviour
{
    #region Singleton Init

    public static NavMeshBaking Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    [SerializeField] GameObject pathfinding;

    public void BuildNavMesh()
    {
        pathfinding.GetComponent<AstarPath>().Scan();
        MenuManager.Instance.OpenMenu("gui");
    }
}


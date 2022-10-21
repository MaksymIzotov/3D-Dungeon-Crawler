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

    public void BuildNavMesh(NavMeshSurface[] surfaces)
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }

        MenuManager.Instance.OpenMenu("gui");
    }
}


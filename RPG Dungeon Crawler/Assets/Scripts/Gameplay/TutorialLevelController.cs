using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelController : MonoBehaviour
{
    [SerializeField] private string[] tutorialSteps;

    private int index = 0;

    void Start()
    {
        GetComponent<PlayerSpawner>().SpawnPlayer();
        NavMeshBaking.Instance.BuildNavMesh();
    }


}

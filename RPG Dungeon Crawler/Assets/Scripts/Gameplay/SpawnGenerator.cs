using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    [SerializeField] private GameObject generator;

    void Start()
    {
        Instantiate(generator, Vector3.zero, Quaternion.identity);
    }
}

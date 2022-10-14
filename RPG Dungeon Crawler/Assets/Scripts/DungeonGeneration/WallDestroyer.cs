using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    private void Start()
    {
        int layerMask = 1 << 12;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.01f, layerMask);

        if (hitColliders.Length == 2)
        {
            DestroyWalls(hitColliders);
        }


        Destroy(gameObject, 2);
    }

    private void DestroyWalls(Collider[] walls)
    {

        Destroy(walls[0].transform.parent.gameObject);
        Destroy(walls[1].transform.parent.gameObject);
        Destroy(walls[1].gameObject);
    }
}

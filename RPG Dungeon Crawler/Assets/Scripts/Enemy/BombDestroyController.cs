using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyController : MonoBehaviour
{
    private void Start()
    {
        Invoke("Explode", 40);
    }

    private void Explode()
    {
        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().AttackingState);
    }
}

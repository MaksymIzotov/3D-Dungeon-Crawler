using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRootObjectReference : MonoBehaviour
{
    GameObject parent;

    private void Start()
    {
        parent = transform.root.gameObject;
    }
    private void Attack()
    {
        parent.GetComponent<EnemyAudio>().PlayAttack();
    }
    private void AttackAbove()
    {
        parent.GetComponent<EnemyAudio>().PlayAttackAbove();
    }
}

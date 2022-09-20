using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProperty", menuName = "Properties/Attack", order = 2)]
public class EnemyAttack : ScriptableObject
{
    public float attackDelay;
    public float damage;
    public float preAttackTime;

    public GameObject bullet;
}

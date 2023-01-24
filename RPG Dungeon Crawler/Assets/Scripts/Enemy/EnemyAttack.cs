using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProperty", menuName = "Properties/Attack", order = 2)]
public class EnemyAttack : ScriptableObject
{
    [Header("Melee enemies")]
    public float attackDelayMelee;
    public float damage;
    public float preAttackTimeMelee;

    [Space(10)]
    [Header("Shooting enemies")]

    public float attackDelayShooting;
    public float preAttackTimeShooting;
    public float pushDamage;
    public GameObject bullet;
}

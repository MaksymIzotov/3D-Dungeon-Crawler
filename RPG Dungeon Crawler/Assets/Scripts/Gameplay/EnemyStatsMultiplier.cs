using UnityEngine;

[CreateAssetMenu(fileName = "Current enemy difficulty", menuName = "Multipliers/Enemy multipliers", order = 1)]
public class EnemyStatsMultiplier : ScriptableObject
{
    public float healthMult;
    public float damageMult;
}

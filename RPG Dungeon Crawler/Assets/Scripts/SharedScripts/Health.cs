using UnityEngine;

[CreateAssetMenu(fileName = "NewProperty", menuName = "Properties/Health", order = 1)]
public class Health : ScriptableObject
{
    public float healthPoints;
    public float defence;
    public float healthRegen;
}

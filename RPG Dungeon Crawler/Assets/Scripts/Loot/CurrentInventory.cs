using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 1)]
public class CurrentInventory : ScriptableObject
{
    public List<LootInfo> GlobalInventory;
    public List<LootInfo> LevelInventory;
}

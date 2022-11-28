using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemsToDropSettings", menuName = "Loot/DropItems", order = 1)]
public class ItemsToDrop : ScriptableObject
{
    [System.Serializable]
    public struct Item {
        public GameObject prefab;
        public float dropChance;
    }

    public Item[] items;
}

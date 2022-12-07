using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 1)]
public class CurrentInventory : ScriptableObject
{
    [System.Serializable]
    public struct SpellInfo
    {
        public string spellName;
        public GameObject buttonPrefab;
    }

    public List<Item> GlobalInventory;
    public List<Item> LevelInventory;

    public Money moneyInventory;

    public Spell[] spells;
    public List<SpellInfo> spellsInventory;

    public Item usable;
    public Item armor;
    public Item weapon;
}

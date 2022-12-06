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

    public Spell[] spells;
    public List<SpellInfo> spellsInventory;
}

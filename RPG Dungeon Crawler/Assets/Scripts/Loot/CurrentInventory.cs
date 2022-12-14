using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 1)]
public class CurrentInventory : ScriptableObject
{
    public List<Item> AllItemsInTheGame;
    public List<Spell> AllSpellsInTheGame;

    public List<Item> GlobalInventory;
    public List<Item> LevelInventory;

    public Money moneyInventory;

    public Spell[] equipedSpells;
    public List<Spell> spellsInventory;

    public Item usable;
    public Item armor;
    public Item weapon;
}

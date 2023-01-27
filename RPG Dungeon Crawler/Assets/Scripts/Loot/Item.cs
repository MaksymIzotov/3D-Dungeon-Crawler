using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon = 0,
        Armor = 1,
        Usable = 2
    }

    public enum ItemRarity
    {
        Blue = 0,
        Purple = 1,
        Red = 2
    }

    [Header("Item")]
    public string itemName;
    public ItemType type;
    public ItemRarity rarity;
    public float usageTime;

    [Space(10)]
    [Header("Icon")]

    public Sprite icon;

    [Space(10)]
    [Header("Price")]

    public int clonePrice;
    public int upgradePrice;
    public int evolvePrice;

    [Space(10)]
    [Header("Upgrades")]

    public Item evolutionItem;
    public int lvl;
    public int maxLvl;
    public Item itemReference;

    [Space(10)]
    [Header("Description")]

    public PassiveDescription passiveDescription;
    public virtual void ApplyStats(GameObject player)
    {

    }

    public virtual void PreUse(GameObject player)
    {

    }

    public virtual void Use(GameObject player)
    {

    }

    public virtual void Passive(GameObject player)
    {

    }

    public virtual void UpgradeStats()
    {

    }

    public virtual void Reset()
    {

    }

    public virtual string Stats()
    {
        return null;
    }
    public virtual string Desription()
    {
        return null;
    }
}

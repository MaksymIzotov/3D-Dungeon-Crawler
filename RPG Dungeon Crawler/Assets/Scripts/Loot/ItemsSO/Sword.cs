using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

[CreateAssetMenu(fileName = "Sword", menuName = "Loot/Items/Sword", order = 1)]
public class Sword : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float criticalChance;
    public float criticalDamage;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float criticalChanceAdd;
    public float criticalDamageAdd;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_criticalChance;
    public float def_criticalDamage;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        player.GetComponent<PlayerPassives>().SetupCriticalDamage(criticalChance, criticalDamage, passiveDescription);
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;


        criticalChance += criticalChance;
        criticalDamage += criticalDamageAdd;

    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A sword that gives you a chance to hit a critical strike"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A sword that gives you a chance to hit a critical strike"; //Purple rarity

        return "A sword that gives you a chance to hit a critical strike"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Critical chance: " + criticalChance + "\nCritical damage %: " + criticalDamage; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Critical chance: " + criticalChance + "\nCritical damage %: " + criticalDamage; //Purple rarity

        return "Critical chance: " + criticalChance + "\nCritical damage %: " + criticalDamage; //Red rarity
    }

    public override void Reset()
    {
        criticalChance = def_criticalChance;
        criticalDamage = def_criticalDamage;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

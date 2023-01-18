using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hammer", menuName = "Loot/Items/Hammer", order = 1)]
public class Hammer : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float stunChance;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float stunChanceAdd;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_stunChance;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        //Add passive
        player.GetComponent<PlayerPassives>().EnableStun(stunChance);
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;


        stunChance += stunChanceAdd;
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A strong hammer that can stun enemies"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A strong hammer that can stun enemies"; //Purple rarity

        return "A strong hammer that can stun enemies"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Stun chance: " + stunChance.ToString("F"); //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Stun chance: " + stunChance.ToString("F"); ; //Purple rarity

        return "Stun chance: " + stunChance.ToString("F"); //Red rarity
    }

    public override void Reset()
    {
        stunChance = def_stunChance;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

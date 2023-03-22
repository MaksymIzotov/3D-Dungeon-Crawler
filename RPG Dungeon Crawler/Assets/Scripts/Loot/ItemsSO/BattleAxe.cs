using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle Axe", menuName = "Loot/Items/Battle Axe", order = 1)]
public class BattleAxe : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float killChance;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float killChanceAdd;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_killChance;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        player.GetComponent<PlayerPassives>().EnableInstaKill(killChance, passiveDescription); //Add passive
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;

        killChance += killChance;
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A huge battle axe. Has a small chance to instantly kill an enemy"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A huge battle axe. Has a small chance to instantly kill an enemy"; //Purple rarity

        return "A huge battle axe. Has a small chance to instantly kill an enemy"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Kill chance: " + killChance; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Kill chance: " + killChance; //Purple rarity

        return "Kill chance: " + killChance; //Red rarity
    }

    public override void Reset()
    {
        killChance = def_killChance;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

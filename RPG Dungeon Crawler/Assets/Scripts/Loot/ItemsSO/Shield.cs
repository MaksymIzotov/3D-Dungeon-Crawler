using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Loot/Items/Shield", order = 1)]
public class Shield : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float defence;
    public float blockChance;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float defenceAdd;
    public float blockChanceAdd;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_defence;
    public float def_blockChance;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        player.GetComponent<PlayerHealthController>().AddDefence(defence); //Add stats

        if (rarity == ItemRarity.Red)
            player.GetComponent<PlayerPassives>().EnableBlocking(blockChance); //Add passive
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;

        defence += defenceAdd;

        if (blockChance > 0)
            blockChance += blockChanceAdd;
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A shield to protect your body"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A shield to protect your body"; //Purple rarity

        return "A shield to protect your body. Has a chance to fully block income damage"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Defence: " + defence; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Defence: " + defence; //Purple rarity

        return "Defence: " + defence + "\nBlock chance: " + blockChance; //Red rarity
    }

    public override void Reset()
    {
        defence = def_defence;
        blockChance = def_blockChance;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

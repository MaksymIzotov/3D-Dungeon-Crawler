using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chestplate", menuName = "Loot/Items/Chestplate", order = 1)]
public class Chestplate : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float defence;
    public float returnPercentage;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float defenceAdd;
    public float returnPercentageAdd;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_defence;
    public float def_returnPercentage;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {    
        player.GetComponent<PlayerHealthController>().AddDefence(defence); //Add stats

        if (rarity == ItemRarity.Red)
            player.GetComponent<PlayerPassives>().EnableDamageReturn(returnPercentage, passiveDescription); //Add passive
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;

        defence += defenceAdd;

        if (returnPercentage > 0)
            returnPercentage += returnPercentageAdd;
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A chestplate to protect your chest"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A chestplate to protect your chest"; //Purple rarity

        return "A chestplate to protect your chest. Returns a percentage of income damage"; //Red rarity
    }

    public override string Stats()
    {     
        if (rarity == ItemRarity.Blue)
            return "Defence: " + defence; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Defence: " + defence; //Purple rarity

        return "Defence: " + defence + "\nReturn percentage: " + returnPercentage; //Red rarity
    }

    public override void Reset()
    {
        defence = def_defence;
        returnPercentage = def_returnPercentage;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

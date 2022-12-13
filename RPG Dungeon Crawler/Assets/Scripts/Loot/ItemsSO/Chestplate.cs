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

    public override void ApplyStats(GameObject player)
    {    
        player.GetComponent<PlayerHealthController>().AddDefence(defence); //Add stats

        if (rarity == ItemRarity.Red)
            player.GetComponent<PlayerPassives>().EnableDamageReturn(returnPercentage); //Add passive
    }

    public override void UpgradeStats()
    {
        defence++;

        if (returnPercentage > 0)
            returnPercentage++;
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
}

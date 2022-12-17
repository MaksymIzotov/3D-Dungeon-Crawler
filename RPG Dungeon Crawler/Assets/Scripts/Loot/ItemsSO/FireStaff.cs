using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Firestaff", menuName = "Loot/Items/Firestaff", order = 1)]
public class FireStaff : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float damageToFireSpells;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float damageToFireSpellsMult;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_damage;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        //Add stats
        player.GetComponent<PlayerPassives>().fireDamage = damageToFireSpells;

        //Add passive
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;

        damageToFireSpells *= damageToFireSpellsMult;
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A staff with fire crystal. Makes your fire spells stronger"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A staff with fire crystal. Makes your fire spells stronger"; //Purple rarity

        return "A staff with fire crystal. Makes your fire spells stronger"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Damage: " + damageToFireSpells; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Damage: " + damageToFireSpells; ; //Purple rarity

        return "Damage: " + damageToFireSpells; //Red rarity
    }

    public override void Reset()
    {
        damageToFireSpells = def_damage;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

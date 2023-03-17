using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dagger", menuName = "Loot/Items/Dagger", order = 1)]
public class Dagger : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float damage;
    public float attackChance;
    public float stealthAttackDamage;

    [Space(10)]
    [Header("Item Upgrade Stats")]
    public float damageMult;
    public float attackChanceAdd;
    public float stealthAttackDamageMult;
    public float priceMult;

    [Space(20)]
    [Header("Default stats")]
    public float def_damage;
    public float def_attackChance;
    public float def_stealthAttackDamage;
    public int def_upgradePrice;

    public override void ApplyStats(GameObject player)
    {
        player.GetComponent<PlayerPassives>().damage = damage; //Add stats

        if (rarity == ItemRarity.Red)
            player.GetComponent<PlayerPassives>().EnableStealthAttack(attackChance, stealthAttackDamage, passiveDescription); //Add passive
    }

    public override void UpgradeStats()
    {
        float newUpgradePrice = upgradePrice * priceMult;
        upgradePrice = (int)newUpgradePrice;

        damage *= damageMult;

        if (attackChance > 0)
        {
            attackChance += attackChance;
            stealthAttackDamage *= stealthAttackDamageMult;
        }
    }

    public override string Desription()
    {
        if (rarity == ItemRarity.Blue)
            return "A stealthy dagger. Gives more damage to your attacks"; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "A stealthy dagger. Gives more damage to your attacks"; //Purple rarity

        return "A stealthy dagger. Gives more damage to your attacks. Has a chance to attack every enemy in a small radius after using movement spell"; //Red rarity
    }

    public override string Stats()
    {
        if (rarity == ItemRarity.Blue)
            return "Damage: " + damage; //Blue rarity
        if (rarity == ItemRarity.Purple)
            return "Damage: " + damage; //Purple rarity

        return "Damage: " + damage + "\nAttack chance: " + attackChance + "\nAttack damage: " + stealthAttackDamage; //Red rarity
    }

    public override void Reset()
    {
        damage = def_damage;
        attackChance = def_attackChance;
        stealthAttackDamage = def_stealthAttackDamage;
        upgradePrice = def_upgradePrice;
        lvl = 1;
    }
}

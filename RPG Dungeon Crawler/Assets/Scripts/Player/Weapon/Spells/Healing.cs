using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healing", menuName = "Spells/Healing", order = 2)]
public class Healing : Spell
{
    public float hpHealingAmount;

    [Space(10)]
    [Header("Upgrade amount")]
    public float healingUpgradeAmount;
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public float def_hpHealingAmount;
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject parent = spellSpawnpoint.root.gameObject;
        parent.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.HEALINGCROSS_ANIM);
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<PlayerHealthController>().Heal(hpHealingAmount);
    }

    public override string Stats()
    {
        return "Healing amount: " + hpHealingAmount + "\nCooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Bruh, like you don't know what is healing for?";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        hpHealingAmount += healingUpgradeAmount;
        coolDownTime -= cooldownReduce;
    }

    public override void Reset()
    {
        hpHealingAmount = def_hpHealingAmount;
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldSpell", menuName = "Spells/Shield Spell", order = 1)]
public class ShieldSpell : Spell
{
    [Space(10)]
    [Header("Main properties")]
    public int blockAmount;
    public PassiveDescription description;

    [Space(10)]
    [Header("Upgrade amount")]
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public int def_blockAmount;
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.SHIELDSPELL_ANIM);
        
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        spellSpawnpoint.root.GetComponent<PlayerPassives>().EnableShield(blockAmount, description);

        spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), castAudio);
    }

    public override void CastUpgraded(Transform spellProperty)
    {

    }

    public override string Stats()
    {
        return "Block amount: " + blockAmount.ToString("F") + "\nCooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Creates a shield around the player. Fully blocks next attacks.";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        coolDownTime -= cooldownReduce;
        blockAmount++;
    }

    public override void Reset()
    {
        blockAmount = def_blockAmount;
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}

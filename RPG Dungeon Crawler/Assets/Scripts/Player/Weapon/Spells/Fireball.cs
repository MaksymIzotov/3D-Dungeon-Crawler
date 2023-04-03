using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball", order = 1)]
public class Fireball : Spell
{
    public GameObject instantiatePrefab;

    public float damage;
    public bool isFireball;

    [Space(10)]
    [Header("Upgrade amount")]
    public float damageMult;
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public float def_damage;
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject parent = spellSpawnpoint.root.gameObject;
        parent.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.FIREBALL_ANIM);

        spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), preCastAudio);
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject parent = spellSpawnpoint.root.gameObject;
        GameObject fireball = Instantiate(instantiatePrefab, spellSpawnpoint.position, spellSpawnpoint.rotation);

        fireball.GetComponent<FireballController>().SetProperties(damage, isFireball);
    }

    public override void CastUpgraded(Transform spellProperty)
    {
        
    }

    public override string Stats()
    {
        return "Damage: " + damage.ToString("F") + "\nCooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "This. Is. Fireball. Anything else you want to know?";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        coolDownTime -= cooldownReduce;
        damage *= damageMult;
    }

    public override void Reset()
    {
        damage = def_damage;
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}

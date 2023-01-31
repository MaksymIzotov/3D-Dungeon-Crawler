using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball", order = 1)]
public class Fireball : Spell
{
    public GameObject instantiatePrefab;

    public float damage;

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

        //Sound
        parent.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.GetComponent<AudioSource>(), castAudio);
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject parent = spellSpawnpoint.root.gameObject;
        GameObject fireball = Instantiate(instantiatePrefab, spellSpawnpoint.position, spellSpawnpoint.rotation);

        float damageAdd = parent.GetComponent<PlayerPassives>().fireDamage;
        float burnDamage = parent.GetComponent<PlayerPassives>().GetBurnDamage();
        fireball.GetComponent<FireballController>().SetProperties(damage + damageAdd, burnDamage);
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

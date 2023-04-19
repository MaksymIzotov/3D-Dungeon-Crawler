using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Missile", menuName = "Spells/Missile", order = 1)]
public class Missile : Spell
{
    [Space(10)]
    [Header("Main properties")]
    public float damage;
    public GameObject InstantiatePrefab;

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
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.MISSILE_ANIM);

    }

    public override void Cast(Transform spellSpawnpoint)
    {
        //Spawn projectile
        GameObject projectile = Instantiate(InstantiatePrefab, spellSpawnpoint.position, spellSpawnpoint.rotation);
        projectile.GetComponent<MissileController>().Setup(damage);

        //spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), castAudio);
    }

    public override void CastUpgraded(Transform spellProperty)
    {

    }

    public override string Stats()
    {
        return "Damage: " + damage + "\nCooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Creates a projectile which follows any closest enemy.";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        damage *= damageMult;
        coolDownTime -= cooldownReduce;
    }

    public override void Reset()
    {
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;
        damage = def_damage;

        lvl = 1;
    }
}

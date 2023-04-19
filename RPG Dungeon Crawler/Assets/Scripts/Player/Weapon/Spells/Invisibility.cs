using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility", menuName = "Spells/Invisibility", order = 1)]
public class Invisibility : Spell
{
    [Space(10)]
    [Header("Main properties")]
    public PassiveDescription description;

    [Space(10)]
    [Header("Upgrade amount")]
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.INVISIBILITY_ANIM);

    }

    public override void Cast(Transform spellSpawnpoint)
    {
        spellSpawnpoint.root.GetComponent<PlayerPassives>().EnableInvisibility(true, description);
        //spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), castAudio);
    }

    public override void CastUpgraded(Transform spellProperty)
    {

    }

    public override void AfterCast(Transform spellSpawnpoint)
    {
        //Turn off the invisibility
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.INVISIBILITYAWAY_ANIM);
        spellSpawnpoint.root.GetComponent<PlayerPassives>().EnableInvisibility(false, description);

        //Try stealth attack 
        float stealthDamage = spellSpawnpoint.root.GetComponent<PlayerPassives>().TryStealthAttack();
        if (stealthDamage > 0)
        {
            bool isEnemyNear = false;

            Collider[] colliders = Physics.OverlapSphere(spellSpawnpoint.root.position, 7);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag(TAGS.ENEMY_TAG))
                {
                    isEnemyNear = true;
                    col.gameObject.GetComponent<IDamagable>()?.TakeDamage(stealthDamage, spellSpawnpoint.root.gameObject);
                }
            }

            if (isEnemyNear)
                spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayStealthAttack();
        }
    }

    public override string Stats()
    {
        return "Cooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Makes you invisible for some time.";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        coolDownTime -= cooldownReduce;
    }

    public override void Reset()
    {
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}

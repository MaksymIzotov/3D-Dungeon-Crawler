using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball", order = 1)]
public class Fireball : Spell
{
    public GameObject instantiatePrefab;

    public float damage;
    public float burnEffectDuration;
    public float burnDamage;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject parent = spellSpawnpoint.root.gameObject;
        parent.GetComponent<AnimationManager>().PlaySpellAnimation("FireballLowPoly");
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject fireball = Instantiate(instantiatePrefab, spellSpawnpoint.position, spellSpawnpoint.rotation);
        fireball.GetComponent<FireballController>().SetProperties(damage, burnEffectDuration, burnDamage);

        if (isUpgraded)
        {
            CastUpgraded(fireball.transform);
        }
    }

    public override void CastUpgraded(Transform spellProperty)
    {
        spellProperty.GetComponent<FireballController>().Upgrade();
    }

    public override string Stats()
    {
        return "Damage: " + damage + "\nCooldown: " + coolDownTime;
    }

    public override string Desription()
    {
        return "This. Is. Fireball. Anything else you want to know?";
    }
}

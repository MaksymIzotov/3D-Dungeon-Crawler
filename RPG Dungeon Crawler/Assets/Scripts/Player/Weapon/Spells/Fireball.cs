using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball", order = 1)]
public class Fireball : Spell
{
    public GameObject instantiatePrefab;
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
        fireball.GetComponent<FireballController>().burnDuration = burnEffectDuration;
        fireball.GetComponent<FireballController>().burnDamage = burnDamage;
    }
}

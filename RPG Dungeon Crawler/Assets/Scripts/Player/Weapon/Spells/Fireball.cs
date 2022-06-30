using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Spells/Fireball", order = 1)]
public class Fireball : Spell
{
    public GameObject instantiatePrefab;

    public override void PreCast(GameObject parent)
    {
        //Animation
        parent.GetComponent<AnimationManager>().PlaySpellAnimation("Fireball");
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        Instantiate(instantiatePrefab, spellSpawnpoint.position, spellSpawnpoint.rotation);
    }
}

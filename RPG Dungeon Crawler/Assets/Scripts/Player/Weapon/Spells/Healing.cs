using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healing", menuName = "Spells/Healing", order = 2)]
public class Healing : Spell
{
    public float hpHealingAmount;
    public GameObject healingCross;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject parent = spellSpawnpoint.root.gameObject;

        GameObject cross = Instantiate(healingCross, spellSpawnpoint);
        Destroy(cross, activateTime);

        parent.GetComponent<AnimationManager>().PlaySpellAnimation("Healing");
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<PlayerHealthController>().Heal(hpHealingAmount);
    }
}

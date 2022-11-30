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
        parent.GetComponent<AnimationManager>().PlaySpellAnimation("Healing");
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<PlayerHealthController>().Heal(hpHealingAmount);
    }

    public override string Stats()
    {
        return "Healing amount: " + hpHealingAmount + "\nCooldown: " + coolDownTime;
    }

    public override string Desription()
    {
        return "Bruh, like you don't know what is healing for? Are you for real or just pretending that you are?";
    }
}

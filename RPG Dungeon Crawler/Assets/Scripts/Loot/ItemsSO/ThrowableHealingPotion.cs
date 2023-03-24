using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrowableHealingPotion", menuName = "Loot/Items/ThrowableHealingPotion", order = 1)]
public class ThrowableHealingPotion : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float regenAmount;
    public float duration;

    public override void PreUse(GameObject player)
    {
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.HEALINGTHROW_ANIM);
    }

    public override void Use(GameObject player)
    {
        player.GetComponent<PlayerThrowables>().ThrowHealingPotion(regenAmount);
    }

    public override string Desription()
    {
        return "A throwable healing potion. Creates an area where player can get additional health regeneration";
    }

    public override string Stats()
    {
        return "Healing/s: " + regenAmount;
    }
}

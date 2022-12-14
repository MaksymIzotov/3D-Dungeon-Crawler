using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healing potion", menuName = "Loot/Items/Healing potion", order = 1)]
public class HealingPotion : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float healingAmount;

    public override void PreUse(GameObject player)
    {
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.HEALINGPOTION_ANIM);
    }

    public override void Use(GameObject player)
    {
        player.GetComponent<PlayerHealthController>().Heal(healingAmount);
    }

    public override string Desription()
    {
        return "A potion to heal you up"; 
    }

    public override string Stats()
    {
        return "Healing: " + healingAmount;
    }
}

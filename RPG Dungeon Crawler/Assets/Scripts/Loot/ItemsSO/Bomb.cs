using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bomb", menuName = "Loot/Items/Bomb", order = 1)]
public class Bomb : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float damage;

    public override void PreUse(GameObject player)
    {
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.BOMB_ANIM);
    }

    public override void Use(GameObject player)
    {
        player.GetComponent<PlayerThrowables>().ThrowBomb(damage);
    }

    public override string Desription()
    {
        return "A throwable bomb";
    }

    public override string Stats()
    {
        return "Damage: " + damage;
    }
}

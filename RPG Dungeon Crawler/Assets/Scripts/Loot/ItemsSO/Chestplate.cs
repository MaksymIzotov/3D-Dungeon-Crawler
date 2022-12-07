using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chestplate", menuName = "Loot/Items/Chestplate", order = 1)]
public class Chestplate : Item
{
    [Space(10)]
    [Header("Item properties")]
    public float defence;

    public override void ApplyStats(GameObject player)
    {    
        player.GetComponent<PlayerHealthController>().AddDefence(defence);
    }

    public override string Desription()
    {
        return "A chestplate to protect your chest";
    }

    public override string Stats()
    {
        return "Defence: " + defence;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chestplate", menuName = "Loot/Items/Chestplate", order = 1)]
public class Chestplate : Item
{
    public float defence;

    public override void ApplyStats()
    {
        //TOOD: Give stats to player
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

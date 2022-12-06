using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootInfo", menuName = "Loot", order = 1)]
public class LootInfo : ScriptableObject
{
    public string lootName;
    public Sprite icon;
    public GameObject iconPrefab;
    public GameObject buttonPrefab;
    public string description;

    public string Stats()
    {
        return "0";
    }
    //properties
}

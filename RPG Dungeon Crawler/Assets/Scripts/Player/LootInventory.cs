using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootInventory : MonoBehaviour
{
    List<LootInfo> inventory = new List<LootInfo>();

    public void AddItem(LootInfo item)
    {
        inventory.Add(item);
        Debug.Log(item.name);
    }

    public void RemoveItem(LootInfo item)
    {
        inventory.Remove(item);
    }
}

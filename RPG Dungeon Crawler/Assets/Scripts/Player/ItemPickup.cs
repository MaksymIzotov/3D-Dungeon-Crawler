using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    LootInventory inventory;
    private void Start()
    {
        inventory = GetComponent<LootInventory>();
    }

    public void PickupItem(LootInfo info)
    {
        //Add item to player inventory
        inventory.AddItem(info);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAGS.LOOT_TAG))
        {
            other.GetComponent<LootCollecting>().Collect();
        }
    }
}

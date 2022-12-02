using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public void PickupItem(LootInfo info)
    {
        //Add item to player inventory
        LootInventory.Instance.AddItem(info);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag(TAGS.LOOT_TAG))
            other.transform.parent.GetComponent<LootCollecting>().Collect();

    }
}

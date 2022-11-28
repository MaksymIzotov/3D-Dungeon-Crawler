using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void PickupItem()
    {
        //Add item to player inventory
        Debug.Log("Picked up item");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAGS.LOOT_TAG))
        {
            other.GetComponent<LootCollecting>().Collect(PickupItem);
        }
    }
}

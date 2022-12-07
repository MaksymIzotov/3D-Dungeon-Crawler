using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public void PickupItem(Item info)
    {
        //Add item to player inventory
        LootInventory.Instance.AddItem(info);
    }

    public void PickupItem(int amount, ExtensionMethods.MoneyType moneyType)
    {
        //Add money to player inventory
        LootInventory.Instance.AddMoney(amount, moneyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag(TAGS.LOOT_TAG))
            other.transform.parent.GetComponent<LootCollecting>().Collect();
    }
}

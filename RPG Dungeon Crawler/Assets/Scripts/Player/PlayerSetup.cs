using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    private void Start()
    {
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        //Armor setup
        Item equiped_armor = LootInventory.Instance.inventory.armor;

        if (equiped_armor != null)
        {
            equiped_armor.ApplyStats(gameObject);
        }

        //Weapon setup
        Item equiped_weapon = LootInventory.Instance.inventory.weapon;

        //Usable setup
        Item equiped_usable = LootInventory.Instance.inventory.usable;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInventoryController : MonoBehaviour
{
    #region Singleton Init
    public static MenuInventoryController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public CurrentInventory inventory;

    public void AddSpellToInventory(int spellIndex)
    {
        if (SpellsDescription.Instance.currentSpellDisplayed == null)
        {
            inventory.equipedSpells[spellIndex] = null;
        }
        else
        {
            for (int i = 0; i < inventory.equipedSpells.Length; i++)
            {
                if (inventory.equipedSpells[i] == SpellsDescription.Instance.currentSpellDisplayed)
                    inventory.equipedSpells[i] = null;
            }

            inventory.equipedSpells[spellIndex] = SpellsDescription.Instance.currentSpellDisplayed;
        }
    }

    public void AddItemToInventory(int index)
    {
        Item item = InventoryDescription.Instance.currentLootDisplayed;
        if (item == null)
        {
            switch (index)
            {
                case 0:
                    inventory.weapon = null;
                    break;
                case 1:
                    inventory.armor = null;
                    break;
                case 2:
                    inventory.usable = null;
                    break;
            }
        }
        else
        {
            if (index != (int)item.type) { return; }

            switch (item.type)
            {
                case Item.ItemType.Weapon:
                    inventory.weapon = item;
                    break;
                case Item.ItemType.Armor:
                    inventory.armor = item;
                    break;
                case Item.ItemType.Usable:
                    inventory.usable = item;
                    break;
            }
        }
    }
}

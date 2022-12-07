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
        if (SpellsDescription.Instance.currentSpellDisplayed == null) { return; }

        for (int i = 0; i < inventory.spells.Length; i++)
        {
            if (inventory.spells[i] == SpellsDescription.Instance.currentSpellDisplayed)
                inventory.spells[i] = null;
        }

        inventory.spells[spellIndex] = SpellsDescription.Instance.currentSpellDisplayed;
    }

    public void AddItemToInventory(int index)
    {
        Item item = InventoryDescription.Instance.currentLootDisplayed;
        if (item == null) { return; }

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

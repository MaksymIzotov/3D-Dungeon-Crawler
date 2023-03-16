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
    public EnemyStatsMultiplier multipliers;

    public List<Spell> allBlueSpellsReset;
    public List<Spell> allPurpleSpellsReset;
    public List<Spell> allRedSpellsReset;

    [SerializeField] private AudioClip equipItemClip;
    [SerializeField] private AudioClip equipSpellClip;

    public void ClearInventory()
    {
        foreach (Item item in inventory.AllItemsInTheGame)
        {
            item.itemReference.Reset();
        }
        foreach(Spell spell in inventory.AllSpellsInTheGame)
        {
            spell.spellReference.Reset();
        }

        inventory.GlobalInventory.Clear();
        inventory.spellsInventory.Clear();

        for (int i = 0; i < inventory.equipedSpells.Length; i++)
        {
            inventory.equipedSpells[i] = null;
        }

        inventory.moneyInventory.amountBlueScrolls = 10;
        inventory.moneyInventory.amountPurpleScrolls = 0;
        inventory.moneyInventory.amountRedScrolls = 0;
        inventory.moneyInventory.amountCoins = 0;

        inventory.weapon = null;
        inventory.armor = null;
        inventory.usable = null;
    }

    public void AddItem(Item item)
    {
        inventory.GlobalInventory.Remove(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.GlobalInventory.Add(item);
    }

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

            MenuUIManager.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(equipSpellClip, 1);
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
                    if (inventory.weapon != null)
                    {
                        GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                        inventory.weapon = null;
                    }
                    break;
                case 1:
                    if (inventory.armor != null)
                    {
                        GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                        inventory.armor = null;
                    }
                    break;
                case 2:
                    if (inventory.usable != null)
                    {
                        GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                        inventory.usable = null;
                    }
                    break;
            }
        }
        else
        {
            if (index != (int)item.type) { return; }

            switch (item.type)
            {
                case Item.ItemType.Hands:
                    GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                    inventory.weapon = item;
                    break;
                case Item.ItemType.Body:
                    GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                    inventory.armor = item;
                    break;
                case Item.ItemType.Usable:
                    GetComponent<AudioSource>().PlayOneShot(equipItemClip, 1);
                    inventory.usable = item;
                    break;
            }
        }
    }
}

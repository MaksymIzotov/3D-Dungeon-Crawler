using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    #region Singleton Init
    public static MenuUIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private GameObject[] currentSpells;

    [SerializeField] private Transform obtainedSpellsParent;
    [SerializeField] private Transform obtainedItemsParent;

    public void UpdateSpellsIcons()
    {
        Spell[] inv = MenuInventoryController.Instance.inventory.spells;

        for (int i = 0; i < currentSpells.Length; i++)
        {
            if (inv[i] == null)
                currentSpells[i].GetComponent<Image>().sprite = null; //TODO: Add empty spell sprite
            else
                currentSpells[i].GetComponent<Image>().sprite = inv[i].icon;
        }
    }

    public void UpdateSpellButtons()
    {
        List<CurrentInventory.SpellInfo> spells = MenuInventoryController.Instance.inventory.spellsInventory;

        //Clear
        foreach (Transform child in obtainedSpellsParent)
        {
            Destroy(child.gameObject);
        }

        //Update
        foreach (CurrentInventory.SpellInfo spell in spells)
        {
            Instantiate(spell.buttonPrefab, obtainedSpellsParent);
        }
    }

    public void UpdateItemButtons()
    {
        List<Item> items = MenuInventoryController.Instance.inventory.GlobalInventory;
        List<ExtensionMethods.InventoryFoundItem> foundItems = new List<ExtensionMethods.InventoryFoundItem>();

        //Clear
        foreach (Transform child in obtainedItemsParent)
        {
            Destroy(child.gameObject);
        }

        //Update
        foreach (Item item in items)
        {
            bool doExist = false;
            foreach (ExtensionMethods.InventoryFoundItem foundItem in foundItems)
            {
                if (foundItem.itemName == item.itemName)
                {
                    doExist = true;
                    break;
                }
            }

            if (doExist) { continue; }

            ExtensionMethods.InventoryFoundItem newItem = new ExtensionMethods.InventoryFoundItem();
            newItem.itemName = item.itemName;
            newItem.amount = 1;

            foundItems.Add(newItem);
        }

        ExtensionMethods.InventoryFoundItem[] foundItemsArr = foundItems.ToArray();
        int index = 0;

        while (index < foundItemsArr.Length)
        {         
            GameObject lootIcon = Instantiate(GetObjectFromList(items, foundItemsArr, index), obtainedItemsParent);

            int amount = 0;
            foreach (Item item in items)
            {
                if (item.itemName == foundItemsArr[index].itemName)
                    amount++;
            }

            lootIcon.GetComponentInChildren<TMP_Text>().text = "x" + amount;

            index++;
        }
    }

    private GameObject GetObjectFromList(List<Item> items, ExtensionMethods.InventoryFoundItem[] foundItemsArr, int index)
    {
        foreach (Item item in items)
        {
            if (item.itemName == foundItemsArr[index].itemName)
            {
                return item.menuButtonPrefab;
            }
        }

        return null;
    }
}

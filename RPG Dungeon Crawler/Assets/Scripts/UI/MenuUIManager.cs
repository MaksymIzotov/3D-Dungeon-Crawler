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

    [Header("Spells")]

    [SerializeField] private GameObject[] currentSpells;
    [SerializeField] private Transform obtainedSpellsParent;

    [Space(10)]
    [Header("Items")]

    [SerializeField] private Transform obtainedItemsParent;
    [SerializeField] private GameObject weaponSlot;
    [SerializeField] private GameObject armorSlot;
    [SerializeField] private GameObject usableSlot;

    [Space(10)]
    [Header("Money")]

    [SerializeField] private TMP_Text coinsAmount;
    [SerializeField] private TMP_Text blueScrollsAmount;
    [SerializeField] private TMP_Text purpleScrollsAmount;
    [SerializeField] private TMP_Text redScrollsAmount;

    [Space(10)]
    [Header("Boss Menu")]

    [SerializeField] private TMP_Text crystalsAmount;
    [SerializeField] private int crystalsNeededForBoss;

    [Space(10)]
    [Header("Other")]

    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private GameObject spellButtonPrefab;

    [SerializeField] private Sprite armorSlotIcon;
    [SerializeField] private Sprite weaponSlotIcon;
    [SerializeField] private Sprite usableSlotIcon;

    [SerializeField] private Sprite spellSlotIcon;

    public void UpdateCrystalAmount()
    {
        crystalsAmount.text = MenuInventoryController.Instance.inventory.moneyInventory.amountCrystals + "/" + crystalsNeededForBoss; 
    }

    public void UpdateMoneyAmount()
    {
        Money money = MenuInventoryController.Instance.inventory.moneyInventory;

        blueScrollsAmount.text = "x" + money.amountBlueScrolls;
        purpleScrollsAmount.text = "x" + money.amountPurpleScrolls;
        redScrollsAmount.text = "x" + money.amountRedScrolls;
        coinsAmount.text = "x" + money.amountCoins;
    }

    public void UpdateSpellsIcons()
    {
        Spell[] inv = MenuInventoryController.Instance.inventory.equipedSpells;

        for (int i = 0; i < currentSpells.Length; i++)
        {
            if (inv[i] == null)
                currentSpells[i].GetComponent<Image>().sprite = spellSlotIcon; 
            else
                currentSpells[i].GetComponent<Image>().sprite = inv[i].icon;
        }
    }

    public void UpdateSpellButtons()
    {
        List<Spell> spells = MenuInventoryController.Instance.inventory.spellsInventory;

        //Clear
        foreach (Transform child in obtainedSpellsParent)
        {
            Destroy(child.gameObject);
        }

        //Update
        foreach (Spell spell in spells)
        {
            spellButtonPrefab.GetComponent<Image>().sprite = spell.icon;
            spellButtonPrefab.GetComponent<ButtonEventSubscriber>().currentSpellProperties = spell.spellReference;
            Instantiate(spellButtonPrefab, obtainedSpellsParent);
        }
    }

    public void UpdateItemIcons()
    {
        bool isUsableExist = false;

        if (MenuInventoryController.Instance.inventory.usable != null)
        {
            foreach(Item item in MenuInventoryController.Instance.inventory.GlobalInventory)
            {
                if(item.itemName == MenuInventoryController.Instance.inventory.usable.itemName)
                {
                    isUsableExist = true;   
                }
            }

            if (!isUsableExist)
                MenuInventoryController.Instance.inventory.usable = null;
        }

        if (MenuInventoryController.Instance.inventory.weapon != null)
            weaponSlot.GetComponent<Image>().sprite = MenuInventoryController.Instance.inventory.weapon.icon;
        else
            weaponSlot.GetComponent<Image>().sprite = weaponSlotIcon; 

        if (MenuInventoryController.Instance.inventory.armor != null)
            armorSlot.GetComponent<Image>().sprite = MenuInventoryController.Instance.inventory.armor.icon;
        else
            armorSlot.GetComponent<Image>().sprite = armorSlotIcon; 

        if (MenuInventoryController.Instance.inventory.usable != null)
            usableSlot.GetComponent<Image>().sprite = MenuInventoryController.Instance.inventory.usable.icon;
        else
            usableSlot.GetComponent<Image>().sprite = usableSlotIcon; 
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
                itemButtonPrefab.GetComponent<Image>().sprite = item.icon;
                itemButtonPrefab.GetComponent<ButtonEventSubscriber>().currentItemProperties = item.itemReference;
                return itemButtonPrefab;
            }
        }

        return null;
    }
}

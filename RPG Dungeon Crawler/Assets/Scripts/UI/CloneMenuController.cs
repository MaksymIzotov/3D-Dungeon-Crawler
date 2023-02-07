using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloneMenuController : MonoBehaviour
{
    #region Singleton Init

    public static CloneMenuController Instance;
    private void Awake()
    {
        Instance = this;   
    }

    #endregion

    private Item currentItem;

    [SerializeField] private Transform obtainedItemsParent;
    [SerializeField] private GameObject descriptionParent;

    [SerializeField] private GameObject moneyAmount;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text description;
    [SerializeField] private GameObject price;
    [SerializeField] private TMP_Text levelText;

    [SerializeField] private GameObject itemButtonPrefab;

    [SerializeField] private AudioClip cloneClip;

    public void ShowDescription(Item item)
    {
        descriptionParent.SetActive(true);

        icon.sprite = item.icon;
        itemName.text = item.itemName;
        stats.text = item.Stats();
        description.text = item.Desription();
        price.GetComponentInChildren<TMP_Text>().text = "x" + item.clonePrice;
        levelText.text = "Lvl " + item.lvl;

        currentItem = item;
    }

    public void HideDescription()
    {
        currentItem = null;
        descriptionParent.SetActive(false);
    }

    public void UpdateCurrentMoney()
    {
        moneyAmount.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountCoins;
    }

    public void UpdateItemList()
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
            if (item.evolutionItem == null) { continue; }

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

    public void CloneItem()
    {
        if (MenuInventoryController.Instance.inventory.moneyInventory.amountCoins < currentItem.clonePrice) { return; }

        MenuUIManager.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(cloneClip, 1);
        MenuInventoryController.Instance.inventory.GlobalInventory.Add(currentItem);
        MenuInventoryController.Instance.inventory.moneyInventory.amountCoins -= currentItem.clonePrice;
    }
}

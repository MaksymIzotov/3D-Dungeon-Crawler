using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootInventory : MonoBehaviour
{
    #region Singleton Init
    public static LootInventory Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public CurrentInventory inventory;

    [HideInInspector] public int collectedScrollsBlue;
    [HideInInspector] public int collectedScrollsPurple;
    [HideInInspector] public int collectedScrollsRed;
    [HideInInspector] public int collectedCoins;

    private void Start()
    {
        ClearInventory();
    }

    public void AddItem(Item item)
    {
        LootQueue.Instance.AddItemToQueue(item.itemName, 1);
        inventory.LevelInventory.Add(item);
    }

    public void AddMoney(int amount, ExtensionMethods.MoneyType moneyType)
    {
        switch (moneyType)
        {
            case ExtensionMethods.MoneyType.ScrollBlue:
                collectedScrollsBlue += amount;
                LootQueue.Instance.AddItemToQueue("Spell Scroll (Blue)", amount);
                break;
            case ExtensionMethods.MoneyType.ScrollRed:
                collectedScrollsRed += amount;
                LootQueue.Instance.AddItemToQueue("Spell Scroll (Red)", amount);
                break;
            case ExtensionMethods.MoneyType.ScrollPurple:
                collectedScrollsPurple += amount;
                LootQueue.Instance.AddItemToQueue("Spell Scroll (Purple)", amount);
                break;
            case ExtensionMethods.MoneyType.Coin:
                collectedCoins += amount;
                LootQueue.Instance.AddItemToQueue("Coins", amount);
                break;
        }
    }

    public void RemoveItem(Item item)
    {
        inventory.LevelInventory.Remove(item);
    }

    public void ClearInventory()
    {
        collectedScrollsBlue = 0;
        collectedScrollsPurple = 0;
        collectedScrollsRed = 0;
        collectedCoins = 0;

        inventory.LevelInventory.Clear();
    }

    public void TransferToGlobal()
    {
        inventory.moneyInventory.amountBlueScrolls += collectedScrollsBlue;
        inventory.moneyInventory.amountPurpleScrolls += collectedScrollsPurple;
        inventory.moneyInventory.amountRedScrolls += collectedScrollsRed;
        inventory.moneyInventory.amountCoins += collectedCoins;

        inventory.GlobalInventory.AddRange(inventory.LevelInventory);
    }
}

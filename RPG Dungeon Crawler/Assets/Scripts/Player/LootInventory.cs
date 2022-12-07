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
        inventory.LevelInventory.Add(item);
    }

    public void AddMoney(int amount, ExtensionMethods.MoneyType moneyType)
    {
        if(moneyType == ExtensionMethods.MoneyType.ScrollBlue)
        {
            collectedScrollsBlue += amount;
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

        inventory.GlobalInventory.AddRange(inventory.LevelInventory);
    }
}

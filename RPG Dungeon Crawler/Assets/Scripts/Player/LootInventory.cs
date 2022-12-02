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

    private void Start()
    {
        ClearInventory();
    }

    public void AddItem(LootInfo item)
    {
        inventory.LevelInventory.Add(item);
    }

    public void RemoveItem(LootInfo item)
    {
        inventory.LevelInventory.Remove(item);
    }

    public void ClearInventory()
    {
        inventory.LevelInventory.Clear();
    }

    public void TransferToGlobal()
    {
        inventory.GlobalInventory.AddRange(inventory.LevelInventory);
    }
}

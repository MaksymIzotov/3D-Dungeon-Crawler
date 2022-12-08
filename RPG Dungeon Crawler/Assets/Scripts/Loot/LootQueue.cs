using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootQueue : MonoBehaviour
{
    #region Singleton Init

    public static LootQueue Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public struct Items
    {
        public string itemName;
        public int amount;
    }

    private Queue<Items> itemQueue = new Queue<Items>();
    private bool isReady = true;

    [SerializeField] private GameObject textPrefab;
    [SerializeField] private Transform textParent;

    public void ReadyUp()
    {
        isReady = true;
    }

    public void AddItemToQueue(string _itemName, int _amount)
    {
        Items newItem = new Items();
        newItem.itemName = _itemName;
        newItem.amount = _amount;

        itemQueue.Enqueue(newItem);
    }

    private void PopItemFromQueue()
    {
        Items newItem = itemQueue.Dequeue();

        GameObject text = Instantiate(textPrefab, textParent);
        text.transform.GetComponent<CollectedLootTextController>().SetupGO(newItem.itemName, newItem.amount);

        isReady = false;
    }

    private void Update()
    {
        if (!isReady) { return; }

        if (itemQueue.Count > 0)
            PopItemFromQueue();
    }
}

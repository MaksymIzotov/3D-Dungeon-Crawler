using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectedLootTextController : MonoBehaviour
{
    public void SetupGO(string itemName, int amount)
    {
        GetComponent<TMP_Text>().text = itemName + " x" + amount;
    }

    private void DestroyGO()
    {
        LootQueue.Instance.ReadyUp();
        Destroy(gameObject);
    }
}

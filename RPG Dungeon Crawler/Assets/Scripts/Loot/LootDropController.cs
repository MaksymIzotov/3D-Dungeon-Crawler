using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropController : MonoBehaviour
{
    [SerializeField] private ItemsToDrop settings;
    [SerializeField] private Transform lootSpawnPoint;

    public void DropItem()
    {
        //TODO: Random
        GameObject loot = Instantiate(settings.items[0].prefab, lootSpawnPoint.position, Quaternion.Euler(new Vector3(-90, Random.Range(0, 360), 0)));

        Vector3 forceDir = new Vector3(Random.Range(-1,1), 1, Random.Range(-1,1));
        loot.GetComponent<Rigidbody>().AddForce(forceDir * 800);
    }
}

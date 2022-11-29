using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropController : MonoBehaviour
{
    [SerializeField] private ItemsToDrop settings;
    [SerializeField] private Transform lootSpawnPoint;

    public void DropItem()
    {
        for (int i = 0; i < settings.items.Length; i++)
        {
            float chance = Random.Range(0, 100);

            if (chance < settings.items[i].dropChance)
                Spawn(i);
        }
    }

    private void Spawn(int index)
    {
        GameObject loot = Instantiate(settings.items[index].prefab, lootSpawnPoint.position, Quaternion.Euler(new Vector3(-90, Random.Range(0, 360), 0)));

        Vector3 forceDir = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));
        loot.GetComponent<Rigidbody>().AddForce(forceDir * 800);
    }
}

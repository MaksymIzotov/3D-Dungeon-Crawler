using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowables : MonoBehaviour
{
    [Header("Bomb")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform spellSpawnPointRight;

    [Space(10)]
    [Header("Healing potion")]
    [SerializeField] private GameObject healingPotionPrefab;

    public void ThrowBomb(float damage)
    {
        Quaternion rot = new Quaternion(Camera.main.transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        GameObject bomb = Instantiate(bombPrefab, spellSpawnPointRight.position, rot);
        bomb.GetComponent<BombController>().SetupDamage(damage);
    }

    public void ThrowHealingPotion(float regenAmount)
    {
        Quaternion rot = new Quaternion(Camera.main.transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        GameObject healingPotion = Instantiate(healingPotionPrefab, spellSpawnPointRight.position, rot);
        healingPotion.GetComponent<ThrowableHealingPotionController>().SetupHealing(regenAmount);
    }
}

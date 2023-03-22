using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowables : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform spellSpawnPointRight;

    public void ThrowBomb(float damage)
    {
        Quaternion rot = new Quaternion(Camera.main.transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        GameObject bomb = Instantiate(bombPrefab, spellSpawnPointRight.position, rot);
        bomb.GetComponent<BombController>().SetupDamage(damage);
    }
}

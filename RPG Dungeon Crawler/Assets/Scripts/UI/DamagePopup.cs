using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Instance;

    public float randomMin;
    public float randomMax;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject damageText;

    public void ShowDamage(float damage, Transform pos, float height)
    {
        Vector3 spawnPos = new Vector3(pos.position.x + Random.Range(randomMin,randomMax), pos.position.y + height, pos.position.z + Random.Range(randomMin, randomMax));
        GameObject text = Instantiate(damageText, spawnPos, Quaternion.identity);
        text.GetComponent<TMP_Text>().text = damage.ToString();
    }
}

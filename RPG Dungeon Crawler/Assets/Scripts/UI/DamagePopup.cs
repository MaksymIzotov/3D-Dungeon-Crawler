using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.MeshOperations;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Instance;

    public float randomMin;
    public float randomMax;

    public GameObject hpTextAnim;
    public GameObject hpText;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject damageText;

    public void ShowDamage(float damage, Transform pos, Transform damageTextParent)
    {
        Vector3 spawnPos = new Vector3(pos.position.x + Random.Range(randomMin, randomMax), damageTextParent.position.y, pos.position.z + Random.Range(randomMin, randomMax));
        GameObject text = Instantiate(damageText, spawnPos, Quaternion.identity);

        if (damage >= 99999)
            text.GetComponent<TMP_Text>().text = "Insta Kill";
        else
            text.GetComponent<TMP_Text>().text = damage.ToString("F0");
    }

    public void DamageEffect(float damage)
    {
        GameObject hpGO = Instantiate(hpTextAnim, hpText.transform);
        hpGO.GetComponent<TMP_Text>().text = damage.ToString("F0");
    }
}

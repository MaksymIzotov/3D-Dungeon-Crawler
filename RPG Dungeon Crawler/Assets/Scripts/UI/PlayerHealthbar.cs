using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    private Image healthBar;

    private float currentValue = 1;

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag(TAGS.HEALTHBAR_TAG).GetComponent<Image>();
    }

    void Update()
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentValue, 2f * Time.deltaTime);
    }

    public void UpdateHealthbarValue(float maxHp, float currentHp)
    {
        currentValue = ExtensionMethods.Remap(currentHp, 0, maxHp, 0, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Transform healthBar;

    private float currentValue = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
    }

    void Update()
    {
        healthBar.parent.LookAt(player.transform);

        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthBar.localScale = new Vector3(Mathf.Lerp(healthBar.localScale.x, currentValue, 2f * Time.deltaTime), 1, 1);
    }

    public void UpdateHealthbarValue(float maxHp, float currentHp)
    {
        currentValue = ExtensionMethods.Remap(currentHp, 0, maxHp, 0, 1);
    }
}

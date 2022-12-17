using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassives : MonoBehaviour
{
    private bool isReturnDamage = false;
    private float returnDamage;

    public float fireDamage;

    public void EnableDamageReturn(float _returnDamage)
    {
        isReturnDamage = true;
        returnDamage = _returnDamage;
    }

    public void ReturnDamage(GameObject enemy, float damage)
    {
        if (!isReturnDamage) { return; }

        float returnAmount = damage / 100 * returnDamage;
        enemy.GetComponent<EnemyHealthController>().TakeDamage(returnAmount, gameObject);
    }
}

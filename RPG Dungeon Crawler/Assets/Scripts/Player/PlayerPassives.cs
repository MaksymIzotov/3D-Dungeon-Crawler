using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassives : MonoBehaviour
{
    private bool isReturnDamage = false;
    private float returnDamage;

    private bool isBurnEffect = false;
    private float burnDamage;

    public float fireDamage;

    private bool isBlockingOn = false;
    private float blockingChance;

    private bool isStunOn = false;
    private float stunChance;

    public void EnableBurnDamage(float _burnDamage)
    {
        isBurnEffect = true;
        burnDamage = _burnDamage;
    }

    public float GetBurnDamage()
    {
        if (isBurnEffect)
            return burnDamage;
        else
            return 0;
    }

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

    public void EnableBlocking(float chance)
    {
        isBlockingOn = true;
        blockingChance = chance;
    }

    public bool TryBlockDamage()
    {
        if (!isBlockingOn) { return false; }

        int rand = Random.Range(0, 100);
        if(rand < blockingChance)
        {
            return true;
        }

        return false;
    }

    public void EnableStun(float chance)
    {
        isStunOn = true;
        stunChance = chance;
    }

    public bool TryStun()
    {
        if (!isStunOn) { return false; }

        int rand = Random.Range(0, 100);
        if (rand < stunChance)
        {
            return true;
        }

        return false;
    }
}

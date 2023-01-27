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

    public List<PassiveDescription> activePassives = new List<PassiveDescription>();

    public void EnableBurnDamage(float _burnDamage, PassiveDescription passiveDescription)
    {
        isBurnEffect = true;
        burnDamage = _burnDamage;

        activePassives.Add(passiveDescription);
    }

    public float GetBurnDamage()
    {
        if (isBurnEffect)
            return burnDamage;
        else
            return 0;
    }

    public void EnableDamageReturn(float _returnDamage, PassiveDescription passiveDescription)
    {
        isReturnDamage = true;
        returnDamage = _returnDamage;

        activePassives.Add(passiveDescription);
    }

    public void ReturnDamage(GameObject enemy, float damage)
    {
        if (!isReturnDamage) { return; }

        float returnAmount = damage / 100 * returnDamage;
        enemy.GetComponent<EnemyHealthController>().TakeDamage(returnAmount, gameObject);
    }

    public void EnableBlocking(float chance, PassiveDescription passiveDescription)
    {
        isBlockingOn = true;
        blockingChance = chance;

        activePassives.Add(passiveDescription);
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

    public void EnableStun(float chance, PassiveDescription passiveDescription)
    {
        isStunOn = true;
        stunChance = chance;

        activePassives.Add(passiveDescription);
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

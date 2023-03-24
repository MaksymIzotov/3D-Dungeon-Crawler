using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAreaController : MonoBehaviour
{
    private float regenAmount;
    private bool isHealing;

    public void Setup(float _regenAmount)
    {
        regenAmount = _regenAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
            other.gameObject.GetComponent<PlayerHealthController>().AddHealtRegen(regenAmount);

        if (other.CompareTag(TAGS.ENEMY_TAG))
            other.gameObject.GetComponent<EnemyHealthController>().AddHealtRegen(regenAmount);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
            other.gameObject.GetComponent<PlayerHealthController>().AddHealtRegen(-regenAmount);

        if (other.CompareTag(TAGS.ENEMY_TAG))
            other.gameObject.GetComponent<EnemyHealthController>().AddHealtRegen(-regenAmount);
    }

    private void OnDestroy()
    {
        
    }
}

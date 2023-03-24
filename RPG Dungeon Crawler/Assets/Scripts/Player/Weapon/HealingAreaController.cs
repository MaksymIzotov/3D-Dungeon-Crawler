using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAreaController : MonoBehaviour
{
    private float regenAmount;

    private List<GameObject> entities = new List<GameObject>();


    public void Setup(float _regenAmount)
    {
        regenAmount = _regenAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerHealthController>().AddHealtRegen(regenAmount);
            entities.Add(other.gameObject);
        }

        if (other.CompareTag(TAGS.ENEMY_TAG))
        {
            other.gameObject.GetComponent<EnemyHealthController>().AddHealtRegen(regenAmount);
            entities.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerHealthController>().AddHealtRegen(-regenAmount);
            entities.Remove(other.gameObject);
        }

        if (other.CompareTag(TAGS.ENEMY_TAG))
        {
            other.gameObject.GetComponent<EnemyHealthController>().AddHealtRegen(-regenAmount);
            entities.Remove(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        foreach(GameObject entity in entities)
        {
            entity.GetComponent<IDamagable>()?.AddHealtRegen(-regenAmount);
        }
    }
}

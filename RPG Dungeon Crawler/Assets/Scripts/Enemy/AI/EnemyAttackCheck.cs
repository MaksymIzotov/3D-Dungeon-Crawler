using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
            isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TAGS.PLAYER_TAG))
            isPlayerInRange = false;
    }

    public bool GetIsPlayerInRange()
    {
        return isPlayerInRange;
    }
}

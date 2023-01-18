using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatesHelper : MonoBehaviour
{
    [SerializeField] private Transform overheadPoint;
    [SerializeField] private GameObject stunFX;

    public void Stun(float duration)
    {
        StartCoroutine(StunTimer(duration));
    }

    IEnumerator StunTimer(float stunDuration)
    {
        Instantiate(stunFX, overheadPoint);

        yield return new WaitForSeconds(stunDuration);

        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().IdleState);
    }
}

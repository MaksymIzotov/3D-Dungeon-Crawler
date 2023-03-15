using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatesHelper : MonoBehaviour
{
    [SerializeField] private Transform overheadPoint;
    [SerializeField] private GameObject stunFX;

    [SerializeField] private GameObject GroundStompPrefab;

    public void Stun(float duration)
    {
        StartCoroutine(StunTimer(duration));
    }

    IEnumerator StunTimer(float stunDuration)
    {
        Instantiate(stunFX, overheadPoint);

        yield return new WaitForSeconds(stunDuration);

        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().ChasingState);
    }

    public void GroundStomp()
    {
        Vector3 pos = new Vector3(transform.position.x, 0.2f, transform.position.z);
        Instantiate(GroundStompPrefab, pos, Quaternion.identity);
    }

    public void SwitchStateBack()
    {
        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().ChasingState);
    }
}

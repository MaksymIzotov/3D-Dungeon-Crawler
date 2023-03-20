using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    private GameObject player;
    private Quaternion lookRotation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);
    }

    private void Update()
    {
        LookAtPlayer();   
    }

    private void LookAtPlayer()
    {
        lookRotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, lookRotation.y, transform.rotation.z, transform.rotation.w), 10f * Time.deltaTime);
    }
}
